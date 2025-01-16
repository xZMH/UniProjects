package com.example.hope_clinic;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.TextView;

import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;


public class HomeActivity extends AppCompatActivity {

    FirebaseAuth mAuth;
    FirebaseUser user ;
    Button btnUserStatus;
    TextView tvLoggedAs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        this.getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_home);

        mAuth = FirebaseAuth.getInstance();
        user = mAuth.getCurrentUser();
        btnUserStatus = findViewById(R.id.btnUserStatus);
        tvLoggedAs = findViewById(R.id.tvLoggedAs);


        if (mAuth.getCurrentUser() != null) {
            Log.d("AUTH", "User is logged in");
            // User is logged in
            tvLoggedAs.setVisibility(View.VISIBLE);
            tvLoggedAs.append(user.getEmail());
            btnUserStatus.setText("Logout");
            Drawable drawable = getResources().getDrawable(R.drawable.logout); // Replace with your own image resource
            btnUserStatus.setCompoundDrawablesWithIntrinsicBounds(drawable, null, null, null);
        } else {
            Log.d("AUTH", "User is not logged in");
            // User is not logged in
            tvLoggedAs.setVisibility(View.INVISIBLE);
            btnUserStatus.setText("Login");
            Drawable drawable = getResources().getDrawable(R.drawable.login); // Replace with your own image resource
            btnUserStatus.setCompoundDrawablesWithIntrinsicBounds(drawable, null, null, null);
        }

        setupButtonListener(); // Set up the button listener

    }

    public void OnAppointmentClick(View view)
    {

    }

    public void OnDoctorsClick(View view)
    {

    }
    public void OnAmbulanceClick(View view)
    {

    }

    public void OnAboutUsClick(View view)
    {
        startActivity(new Intent(this, AboutUs.class));
    }

    public void onContactUsClick(View view)
    {

    }


    private void setupButtonListener() {
        btnUserStatus.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (mAuth.getCurrentUser() != null)
                {
                    mAuth.signOut();

                    btnUserStatus.setText("Login");
                    tvLoggedAs.setVisibility(View.INVISIBLE);
                    Log.d("AUTH", "User logged out");
                    Drawable drawable = getResources().getDrawable(R.drawable.login); // Replace with your own image resource
                    btnUserStatus.setCompoundDrawablesWithIntrinsicBounds(drawable, null, null, null);
                    setupButtonListener(); // Update the button listener after logging out
                }
                else
                {
                    Log.d("AUTH", "User is not logged in, redirecting to the login page");
                    // User is not logged in, redirect to the login page
                    Intent intent = new Intent(HomeActivity.this, LoginActivity.class);
                    startActivity(intent);
                }
            }
        });
    }

}
