package com.example.hope_clinic;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.core.content.FileProvider;

import android.Manifest;
import android.app.Activity;
import android.app.ProgressDialog;
import android.content.ContentResolver;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.webkit.MimeTypeMap;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.SignInMethodQueryResult;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.StorageReference;
import com.google.firebase.storage.UploadTask;

import java.io.File;
import java.io.IOException;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class SignUpActivity extends AppCompatActivity {
    private static final int CAMERA_PERM_CODE = 101;
    private static final int CAMERA_REQUEST_CODE = 102;
    private static final int GALLERY_REQUEST_CODE = 105;


    private ImageView selectedImage;
    private Button cameraBtn, galleryBtn, uploadBtn;
    private EditText etName, etEmail, etPass, etConfirmPass;
    private String currentPhotoPath;
    private StorageReference storageReference;
    private ProgressDialog progressDialog;
    private Uri imageUri;

    //reference for firebase authentication object
    private FirebaseAuth auth;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);
//        getSupportActionBar().hide(); // this line hides the action bar
        setContentView(R.layout.activity_sign_up);

        selectedImage = findViewById(R.id.displayImageView);
        cameraBtn = findViewById(R.id.btnCamera);
        galleryBtn = findViewById(R.id.btnGallery);
        uploadBtn = findViewById(R.id.btnUpload);

        etName = findViewById(R.id.etName);
        etEmail = findViewById(R.id.etEmail);
        etPass = findViewById(R.id.etPass);
        etConfirmPass =findViewById(R.id.etConfirmPass);

        //get firebase authentication object
        auth = FirebaseAuth.getInstance();
    }

    public void onCameraClick(View view)
    {
        askCameraPermission();

    }

    private void askCameraPermission() {
        if(ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA) != PackageManager.PERMISSION_GRANTED)
        {
            ActivityCompat.requestPermissions(this,new String[] {Manifest.permission.CAMERA}, CAMERA_PERM_CODE);
        }
        else
        {
            //openCamera();
            dispatchTakePictureIntent();

        }

    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {

        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode == CAMERA_PERM_CODE) {
            if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                //openCamera ();
                dispatchTakePictureIntent();

            } else {
                Toast.makeText(this, "Camera permission is required to use Camera", Toast.LENGTH_SHORT).show();
            }
        }
    }

    public void onGalleryClick(View view)
    {

        selectImage();

    }

    private void selectImage()
    {
        Intent intent = new Intent();
        intent.setType("image/*");
        intent.setAction(Intent.ACTION_GET_CONTENT);
        startActivityForResult(intent, 100);
    }


    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {

        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == CAMERA_REQUEST_CODE) {
//            Bitmap image = (Bitmap) data.getExtras().get("data");
//            selectedImage.setImageBitmap(image);
            if (resultCode == Activity.RESULT_OK) {
                File f = new File(currentPhotoPath);
                selectedImage.setImageURI(Uri.fromFile(f));
                Log.d("tag","Absolute url of image is "+ Uri.fromFile(f));

                Intent mediaScanIntent = new Intent(Intent.ACTION_MEDIA_SCANNER_SCAN_FILE);
                Uri contentUri = Uri.fromFile(f);
                mediaScanIntent.setData(contentUri);
                this.sendBroadcast(mediaScanIntent);

            }
        }

        if(requestCode == 100 && data !=null && data.getData() != null)
        {
            imageUri = data.getData();
            Log.d("tag","data.getdata "+ data.getData());
            selectedImage.setImageURI(imageUri);

        }
    }

    private File createImageFile() throws IOException {
        // Create an image file name
        String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(new Date());
        String imageFileName = "JPEG_" + timeStamp + "_";
        //File storageDir = getExternalFilesDir(Environment.DIRECTORY_PICTURES);
        File storageDir = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_PICTURES);
        File image = File.createTempFile(
                imageFileName, /* prefix */
                ".jpg",       /*suffix */
                storageDir     /*directory*/
        );

        //save the file: path for use with ACTION_VIEW intents
        currentPhotoPath = image.getAbsolutePath();
        return image;

    }

    private static final int REQUEST_TAKE_PHOTO = 1;
    Uri photoURI;
    File photoFile;
    private void dispatchTakePictureIntent()
    {
        Intent takePictureIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);

        //Ensure that there is a camera activity to handle the intent
        if(takePictureIntent.resolveActivity(getPackageManager()) != null)
        {
            //Create the file where the photo should go
            photoFile = null;
            try
            {
                photoFile = createImageFile();

            }
            catch (IOException ex)
            {

            }

            //continue only if the file was successfully created
            if(photoFile != null)
            {
                photoURI = FileProvider.getUriForFile(this,"com.example.android.fileprovider",photoFile);
                imageUri=photoURI;
                takePictureIntent.putExtra(MediaStore.EXTRA_OUTPUT,photoURI);
                startActivityForResult(takePictureIntent,CAMERA_REQUEST_CODE);
            }

        }
    }

    public void onUploadClick(View view) {

        Log.e("img value",imageUri==null?"yes":"no");

        if(imageUri==null)
        {
            Toast.makeText(this,"plaese upload image",Toast.LENGTH_SHORT).show();
        }
        else
        {
            uploadImage();
        }

    }

    private void uploadImage() {





        // start to read the email and password from the user
        String name = etName.getText().toString();
        String email = etEmail.getText().toString().trim();
        String password = etPass.getText().toString().trim();
        String ConfirmPass = etConfirmPass.getText().toString().trim();

        if((email.isEmpty())||(password.isEmpty())||(name.isEmpty())||(ConfirmPass.isEmpty()))
        {
            Toast.makeText(this, "Please complete the required fields", Toast.LENGTH_SHORT).show();
        }
        else {
            if (password.equals(ConfirmPass))
            {
                // register the user
                auth.createUserWithEmailAndPassword(email, password)
                        .addOnSuccessListener(new OnSuccessListener<AuthResult>() {
                            @Override
                            public void onSuccess(AuthResult authResult) {
                                String message = "Thanks for registering with us";
                                Log.e("check", "thanks for registering with us");
                                progressDialog = new ProgressDialog(SignUpActivity.this);
                                progressDialog.setTitle("Uploading File....");
                                progressDialog.show();
                                SimpleDateFormat formatter = new SimpleDateFormat("yyyy_MM_dd_HH_mm_ss", Locale.CANADA);
                                Date now = new Date();
                                String fileName = formatter.format(now) + "_ " + etName.getText().toString();


                                storageReference = FirebaseStorage.getInstance().getReference("images/" + fileName);
                                storageReference.putFile(imageUri).addOnSuccessListener(new OnSuccessListener<UploadTask.TaskSnapshot>() {
                                    @Override
                                    public void onSuccess(UploadTask.TaskSnapshot taskSnapshot) {
                                        selectedImage.setImageURI(null);
                                        Toast.makeText(SignUpActivity.this, "Successfully uploaded", Toast.LENGTH_SHORT).show();
                                        if (progressDialog.isShowing())
                                            progressDialog.dismiss();
                                        startActivity(new Intent(SignUpActivity.this, HomeActivity.class));


                                    }
                                }).addOnFailureListener(new OnFailureListener() {
                                    @Override
                                    public void onFailure(@NonNull Exception e) {

                                        if (progressDialog.isShowing())
                                            progressDialog.dismiss();

                                        Toast.makeText(SignUpActivity.this, "Failed to upload", Toast.LENGTH_SHORT).show();

                                    }
                                });


                            }
                        }).addOnFailureListener(new OnFailureListener() {
                            @Override
                            public void onFailure(@NonNull Exception e) {
                                String message = e.getMessage();
                                Log.e("check", message);
                                Toast.makeText(SignUpActivity.this, message, Toast.LENGTH_SHORT).show();

                            }
                        });
                //end of auth part
            }
            else
            {
                Toast.makeText(this, "Confirm password does not match password", Toast.LENGTH_SHORT).show();
            }


        }

    }


    public void onSignupHomeReturnClick(View view)
    {
        startActivity(new Intent(this, LoginActivity.class));

    }
}