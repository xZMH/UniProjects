package com.example.hope_clinic;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class Choose extends AppCompatActivity {

    private Button loginButton, registerButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_choose);
        if (getSupportActionBar() != null) {
            getSupportActionBar().hide();
        }

        // Find the login and register buttons by their IDs
        loginButton = findViewById(R.id.btn_login);
        registerButton = findViewById(R.id.btn_register);

        // Set onClickListener for the login button
        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(Choose.this, LoginActivity.class);
                startActivity(intent);
                finish();
            }
        });

        // Set onClickListener for the register button
        registerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(Choose.this, SignUpActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }
}