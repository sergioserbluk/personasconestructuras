Imports System.IO
Public Class Form1
    Sub cargarDatos()
        Dim archivo As New FileStream("personas.csv", FileMode.OpenOrCreate, FileAccess.Read)
        Dim lector As New StreamReader(archivo)
        While Not lector.EndOfStream
            Dim linea As String = lector.ReadLine
            Dim datos() As String = linea.Split(",")
            Dim persona As New Persona With {.nombre = datos(1), .apellido = datos(2), .anioNacimiento = datos(3)}
            dicpersonal.Add(CInt(datos(0)), persona)
        End While
        lector.Close()
        archivo.Close()
    End Sub
    Sub guardarDatos()
        Dim archivo As New FileStream("personas.csv", FileMode.Create, FileAccess.Write)
        Dim escritor As New StreamWriter(archivo)
        For Each persona In dicpersonal
            escritor.WriteLine(persona.Key & "," & persona.Value.nombre & "," & persona.Value.apellido & "," & persona.Value.anioNacimiento)

        Next
        escritor.Close()
        archivo.Close()
    End Sub
    Public Structure Persona
        Public nombre As String
        Public apellido As String
        Public anioNacimiento As Integer
    End Structure
    Dim dicpersonal As New Dictionary(Of Integer, Persona)
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtDni.Enabled = True
        txtNombre.Enabled = True
        txtApellido.Enabled = True
        txtAnioNacimiento.Enabled = True
        btnNuevo.Enabled = False
        btnGuardar.Enabled = True

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
        For Each persona In dicpersonal
            Dim item As New ListViewItem
            item.Text = persona.Key
            item.SubItems.Add(persona.Value.nombre)
            item.SubItems.Add(persona.Value.apellido)
            item.SubItems.Add(persona.Value.anioNacimiento)
            ListView1.Items.Add(item)

        Next
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        dicpersonal.Add(CInt(txtDni.Text), New Persona With {.nombre = txtNombre.Text, .apellido = txtApellido.Text, .anioNacimiento = CInt(txtAnioNacimiento.Text)})
        guardarDatos()
        ListView1.Items.Clear()
        For Each persona In dicpersonal
            Dim item As New ListViewItem
            item.Text = persona.Key
            item.SubItems.Add(persona.Value.nombre)
            item.SubItems.Add(persona.Value.apellido)
            item.SubItems.Add(persona.Value.anioNacimiento)
            ListView1.Items.Add(item)
        Next
        txtDni.Enabled = False
        txtNombre.Enabled = False
        txtApellido.Enabled = False
        txtAnioNacimiento.Enabled = False
        btnNuevo.Enabled = True
        btnGuardar.Enabled = False
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class
