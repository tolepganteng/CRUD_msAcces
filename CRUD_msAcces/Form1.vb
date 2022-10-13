Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Form1
    Dim Conn As MySqlConnection
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim connString As String

    Sub Koneksi()
        connString = "Server=127.0.0.1;Database=latihan;Uid=root;Pwd="
        Conn = New MySqlConnection(connString)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
        da = New MySqlDataAdapter("Select*from TBL_BARANG", Conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "TBL_BARANG")
        DataGridView1.DataSource = (ds.Tables("TBL_BARANG"))
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then

            MsgBox("Silahkan Isi Semua Form")
        Else
            Dim CMD As MySqlCommand
            Call Koneksi()
            Dim simpan As String = "insert into TBL_BARANG values (" & TextBox1.Text & "," & TextBox2.Text & "," TextBox3.Text & "," TextBox4.Text & "," & ComboBox1.Text & """)
            CMD = New MySqlCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Input data berhasil")
        End If
    End Sub
End Class
