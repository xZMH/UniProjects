package com.example.hope_clinic;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class WelcomeActivity extends AppCompatActivity {

    private Button adminbtn, customerbtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_welcome);
        if (getSupportActionBar() != null) {
            getSupportActionBar().hide();
        }

        // Find the login and register buttons by their IDs
        adminbtn = findViewById(R.id.btn_admin);
        customerbtn = findViewById(R.id.btn_customer);

        // Set onClickListener for the login button
        adminbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(WelcomeActivity.this, AdminActivity.class);
                startActivity(intent);
                finish();
            }
        });

        // Set onClickListener for the register button
        customerbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(WelcomeActivity.this, Choose.class);
                startActivity(intent);
            }
        });
    }
}