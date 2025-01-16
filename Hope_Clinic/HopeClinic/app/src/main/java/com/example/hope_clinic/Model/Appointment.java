package com.example.hope_clinic.Model;

public class Appointment
{
    private int Appointment_Id;
    private String Appointment_Time;
    private String Appointment_Date;
    private String Appointment_Desc;

    public Appointment()
    {
    }

    public Appointment(int appointment_Id, String appointment_Time, String appointment_Date, String appointment_Desc)
    {
        Appointment_Id = appointment_Id;
        Appointment_Time = appointment_Time;
        Appointment_Date = appointment_Date;
        Appointment_Desc = appointment_Desc;
    }

    public int getAppointment_Id()
    {
        return Appointment_Id;
    }

    public void setAppointment_Id(int appointment_Id)
    {
        Appointment_Id = appointment_Id;
    }

    public String getAppointment_Time()
    {
        return Appointment_Time;
    }

    public void setAppointment_Time(String appointment_Time)
    {
        Appointment_Time = appointment_Time;
    }

    public String getAppointment_Date()
    {
        return Appointment_Date;
    }

    public void setAppointment_Date(String appointment_Date)
    {
        Appointment_Date = appointment_Date;
    }

    public String getAppointment_Desc()
    {
        return Appointment_Desc;
    }

    public void setAppointment_Desc(String appointment_Desc)
    {
        Appointment_Desc = appointment_Desc;
    }

    @Override
    public String toString()
    {
        return
                "Appointment_Id:  "  + Appointment_Id + "\n" +
                "Appointment_Time:  " + Appointment_Time + "\n" +
                "Appointment_Date:  " + Appointment_Date + "\n" +
                "Appointment_Desc:  " + Appointment_Desc + "\n";
    }
}
