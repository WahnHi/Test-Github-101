﻿Imports System.Data
Imports System.Data.SqlClient
Public Class check_vaccine
    Private connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kitti\source\repos\final-wellmeadown\final-wellmeadown\wellmeadown-final.mdf;Integrated Security=True;Connect Timeout=30"

    Dim sqlSelectQuery As String = "select * from orderer"
    Dim sqlConnection As New SqlConnection(connectionString)
    Dim sqlCommand As New SqlCommand(sqlSelectQuery, sqlConnection)
    Dim sqlReader As SqlDataReader
    Private Sub check_vaccine_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Public Sub fillterdata(valueTosearch As String)

        Dim sqlSelectQuery As String = "select o.id_card as 'ID card' , o.first_name ++' '++ o.last_name as 'Name'   , v.vaccine_name as 'Vaccine name' ,o.SYSNT_DATE AS 'Order date', o.first_dose ,  o.second_dose  from orderer as o , vaccine as v  where o.vaccine_vaccine_id = v.vaccine_number and o.id_card = " & TextBox1.Text
        Dim sqlCommand As New SqlCommand(sqlSelectQuery, sqlConnection)
        Dim adapter As New SqlDataAdapter(sqlCommand)
        Dim table As New DataTable()

        adapter.Fill(table)
        DataGridView1.DataSource = table


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        fillterdata(TextBox1.Text)
    End Sub
End Class