Public Class Form1
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

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        dicpersonal.Add(CInt(txtDni.Text), New Persona With {.nombre = txtNombre.Text, .apellido = txtApellido.Text, .anioNacimiento = CInt(txtAnioNacimiento.Text)})
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
