package com.example.hope_clinic.Model;

import java.util.List;

public class Patient
{


    private int Patient_id;
    private String Patient_name;
    private String Patient_Address;
    private String Patient_Phone;
    private int Patient_Age;
    private int Patient_Insurance;
    private int Patient_Appointment_Number;

    private List<Appointment> Appointments;

    public Patient()
    {

    }

    public Patient(int patient_id, String patient_name, String patient_Address, String patient_Phone,
                   int patient_Age, int patient_Insurance, int patient_Appointment_Number,
                   List<Appointment> appointments)
    {
        Patient_id = patient_id;
        Patient_name = patient_name;
        Patient_Address = patient_Address;
        Patient_Phone = patient_Phone;
        Patient_Age = patient_Age;
        Patient_Insurance = patient_Insurance;
        Patient_Appointment_Number = patient_Appointment_Number;
        Appointments = appointments;
    }

    public int getPatient_id()
    {
        return Patient_id;
    }

    public void setPatient_id(int patient_id)
    {
        Patient_id = patient_id;
    }

    public String getPatient_name()
    {
        return Patient_name;
    }

    public void setPatient_name(String patient_name)
    {
        Patient_name = patient_name;
    }

    public String getPatient_Address()
    {
        return Patient_Address;
    }

    public void setPatient_Address(String patient_Address)
    {
        Patient_Address = patient_Address;
    }

    public String getPatient_Phone()
    {
        return Patient_Phone;
    }

    public void setPatient_Phone(String patient_Phone)
    {
        Patient_Phone = patient_Phone;
    }

    public int getPatient_Age()
    {
        return Patient_Age;
    }

    public void setPatient_Age(int patient_Age)
    {
        Patient_Age = patient_Age;
    }

    public int getPatient_Insurance()
    {
        return Patient_Insurance;
    }

    public void setPatient_Insurance(int patient_Insurance)
    {
        Patient_Insurance = patient_Insurance;
    }

    public int getPatient_Appointment_Number()
    {
        return Patient_Appointment_Number;
    }

    public void setPatient_Appointment_Number(int patient_Appointment_Number)
    {
        Patient_Appointment_Number = patient_Appointment_Number;
    }

    public List<Appointment> getAppointments()
    {
        return Appointments;
    }

    public void setAppointments(List<Appointment> appointments)
    {
        Appointments = appointments;
    }

    @Override
    public String toString()
    {
        return
                "Patient ID:  " + Patient_id + "\n" +
                "Patient Name:  " + Patient_name + "\n" +
                "Patient_Address:  " + Patient_Address + "\n" +
                "Patient Phone:  " + Patient_Phone + "\n" +
                "Patient Age:  " + Patient_Age + "\n" +
                "Patient Insurance:  " + Patient_Insurance + "\n" +
                "Patient Appointment Number:  " + Patient_Appointment_Number;
    }
}

