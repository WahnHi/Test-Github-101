﻿Imports System.Data
Imports System.Data.SqlClient
Public Class staff_search
    Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kitti\source\repos\final-wellmeadown\final-wellmeadown\wellmeadown-final.mdf;Integrated Security=True;Connect Timeout=30"

    Dim sqlSelectQuery As String = "select * from staff"
    Dim sqlConnection As New SqlConnection(connectionString)
    Dim sqlCommand As New SqlCommand(sqlSelectQuery, sqlConnection)
    Dim sqlReader As SqlDataReader

    Private Sub staff_search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillterdata("")
    End Sub
    Public Sub fillterdata(valueTosearch As String)

        Dim sqlSelectQuery As String = "select staff_number as 'Staff number' , first_name ++ '  ' ++ last_name as 'Name' , qft_type as 'Qualification(s) type' , wex_position as 'Work experience position'  from staff where concat(staff_number , first_name , last_name , qft_type , wex_position) like '%" & valueTosearch & "%'"
        Dim sqlCommand As New SqlCommand(sqlSelectQuery, sqlConnection)
        Dim adapter As New SqlDataAdapter(sqlCommand)
        Dim table As New DataTable()

        adapter.Fill(table)

        DataGridView1.DataSource = table

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        fillterdata(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim sqlSearch As String = "SELECT * FROM staff where concat(staff_number , first_name , last_name) like '%" & TextBox1.Text & "%'"
        Dim sqlConnection As New SqlConnection(connectionString)
        Dim sqlCommand As New SqlCommand(sqlSearch, sqlConnection)
        Dim sqlReader As SqlDataReader

        sqlConnection.Open()
        sqlReader = sqlCommand.ExecuteReader()

        sqlReader.Read()


        staff.Staff_numberTextBox.Text = sqlReader.Item("Staff_Number")
        staff.First_nameTextBox.Text = sqlReader.Item("First_name")
        staff.Last_nameTextBox.Text = sqlReader.Item("Last_name")
        staff.GenderTextBox.Text = sqlReader.Item("Gender")
        staff.TelephoneTextBox.Text = sqlReader.Item("Telephone")
        'staff.Date_of_birthDateTimePicker.Value = sqlReader.Item("Date_of_birth")
        staff.AddressTextBox.Text = sqlReader.Item("Address")
        staff.PositionTextBox.Text = sqlReader.Item("Position")
        staff.NinTextBox.Text = sqlReader.Item("NIN")
        staff.Current_salaryTextBox.Text = sqlReader.Item("Current_Salary")
        staff.Salary_scaleTextBox.Text = sqlReader.Item("Salary_Scale")
        staff.Painweekly_or_monthlyTextBox.Text = sqlReader.Item("PainWeekly_or_Monthly")
        staff.Permanent_or_temporaryTextBox.Text = sqlReader.Item("Permanent_or_Temporary")
        ' staff.Qft_dateDateTimePicker.Value = sqlReader.Item("Qft_date")
        staff.Qft_typeTextBox.Text = sqlReader.Item("QFT_Type")
        staff.Qft_institutionTextBox.Text = sqlReader.Item("QFT_Institution")
        'staff.Wex_start_dateDateTimePicker.Value = sqlReader.Item("Date_of_birth")
        'staff.Wex_finish_dateDateTimePicker.Value = sqlReader.Item("Date_of_birth")
        staff.Wex_positionTextBox.Text = sqlReader.Item("WEX_position")
        staff.Wex_organization_TextBox.Text = sqlReader.Item("WEX_Organization ")


        sqlReader.Close()
        sqlConnection.Close()

        staff.btn_delete.Enabled = True
        staff.btn_edit.Enabled = True
        staff.btn_save.Enabled = False
        staff.Staff_numberTextBox.Enabled = True
        staff.First_nameTextBox.Enabled = True
        staff.Last_nameTextBox.Enabled = True
        staff.GenderTextBox.Enabled = True
        staff.TelephoneTextBox.Enabled = True
        staff.AddressTextBox.Enabled = True
        staff.PositionTextBox.Enabled = True
        staff.NinTextBox.Enabled = True
        staff.Current_salaryTextBox.Enabled = True
        staff.Salary_scaleTextBox.Enabled = True
        staff.Painweekly_or_monthlyTextBox.Enabled = True
        staff.Permanent_or_temporaryTextBox.Enabled = True
        staff.Qft_typeTextBox.Enabled = True
        staff.Qft_institutionTextBox.Enabled = True
        staff.Wex_positionTextBox.Enabled = True
        staff.Wex_organization_TextBox.Enabled = True
        staff.Qft_dateDateTimePicker.Enabled = True
        staff.Wex_start_dateDateTimePicker.Enabled = True
        staff.Wex_finish_dateDateTimePicker.Enabled = True

        Me.Close()

    End Sub

End Class