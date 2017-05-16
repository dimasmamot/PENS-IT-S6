VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   9270
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   13185
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   9.75
      Charset         =   178
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   ScaleHeight     =   618
   ScaleMode       =   3  'Pixel
   ScaleWidth      =   879
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton Command4 
      Caption         =   "Histogram Hue"
      Height          =   495
      Left            =   120
      TabIndex        =   7
      Top             =   4920
      Width           =   3735
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Histogram Segmentasi Dengan Warna Acuan"
      Height          =   495
      Left            =   120
      TabIndex        =   6
      Top             =   4440
      Width           =   3735
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Histogram Indeks"
      Height          =   495
      Left            =   120
      TabIndex        =   5
      Top             =   3960
      Width           =   3735
   End
   Begin VB.TextBox Text1 
      Alignment       =   1  'Right Justify
      Height          =   375
      Left            =   3120
      TabIndex        =   4
      Text            =   "256"
      Top             =   3000
      Width           =   735
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Histogram R-G-B"
      Height          =   495
      Left            =   120
      TabIndex        =   2
      Top             =   3480
      Width           =   3735
   End
   Begin VB.PictureBox Picture2 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BackColor       =   &H80000005&
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   178
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   2775
      Left            =   3960
      ScaleHeight     =   2745
      ScaleWidth      =   8985
      TabIndex        =   1
      Top             =   120
      Width           =   9015
   End
   Begin VB.PictureBox Picture1 
      Appearance      =   0  'Flat
      AutoRedraw      =   -1  'True
      BackColor       =   &H80000005&
      BorderStyle     =   0  'None
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   178
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   2535
      Left            =   240
      Picture         =   "Form1.frx":0000
      ScaleHeight     =   169
      ScaleMode       =   3  'Pixel
      ScaleWidth      =   233
      TabIndex        =   0
      Top             =   240
      Width           =   3495
   End
   Begin VB.Label Label1 
      Caption         =   "Kuantisasi Derajat Keabuan"
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   3000
      Width           =   2775
   End
   Begin VB.Shape Shape1 
      BackColor       =   &H00FFFFFF&
      BackStyle       =   1  'Opaque
      Height          =   2775
      Left            =   120
      Top             =   120
      Width           =   3735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim nx, ny As Integer
Dim h(1000) As Single

Private Sub Command1_Click()
k = Val(Text1)
bg = Int(256 / k)
For i = 0 To k * 3
    h(i) = 0
Next i
For i = 0 To nx - 1
    For j = 0 To ny - 1
        w = Picture1.Point(i, j)
        r = w And RGB(255, 0, 0)
        g = Int((w And RGB(0, 255, 0)) / 256)
        b = Int(Int((w And RGB(0, 0, 255)) / 256) / 256)
        r = Int(r / bg)
        g = Int(g / bg)
        b = Int(b / bg)
        h(r) = h(r) + 1
        h(k + g) = h(k + g) + 1
        h(2 * k + b) = h(2 * k + b) + 1
    Next j
Next i
hmaks = 0
For i = 0 To k * 3
    If h(i) > hmaks Then hmaks = h(i)
Next i
Picture2.ScaleHeight = hmaks
Picture2.ScaleWidth = k * 3
Picture2.Cls
For i = 0 To k - 1
    Picture2.Line (i, hmaks)-(i + 1, hmaks - h(i)), RGB(255, 0, 0), BF
    Picture2.Line (k + i, hmaks)-(k + i + 1, hmaks - h(k + i)), RGB(0, 255, 0), BF
    Picture2.Line (2 * k + i, hmaks)-(2 * k + i + 1, hmaks - h(2 * k + i)), RGB(0, 0, 255), BF
    If k < 128 Then
    Picture2.Line (i, hmaks)-(i + 1, hmaks - h(i)), RGB(0, 0, 0), B
    Picture2.Line (k + i, hmaks)-(k + i + 1, hmaks - h(k + i)), RGB(0, 0, 0), B
    Picture2.Line (2 * k + i, hmaks)-(2 * k + i + 1, hmaks - h(2 * k + i)), RGB(0, 0, 0), B
    End If
Next i
Picture2.Refresh
End Sub

Private Sub Command2_Click()
k = Val(Text1)
bg = Int(256 / k)
For i = 0 To k ^ 3
    h(i) = 0
Next i
For i = 0 To nx - 1
    For j = 0 To ny - 1
        w = Picture1.Point(i, j)
        r = w And RGB(255, 0, 0)
        g = Int((w And RGB(0, 255, 0)) / 256)
        b = Int(Int((w And RGB(0, 0, 255)) / 256) / 256)
        r = Int(r / bg)
        g = Int(g / bg)
        b = Int(b / bg)
        indek = k ^ 2 * r + k * g + b
        h(indek) = h(indek) + 1
    Next j
Next i
hmaks = 0
For i = 0 To k ^ 3 - 1
    If h(i) > hmaks Then hmaks = h(i)
Next i
Picture2.ScaleHeight = hmaks
Picture2.ScaleWidth = k ^ 3
Picture2.Cls
For i = 0 To k ^ 3 - 1
    Picture2.Line (i, hmaks)-(i + 1, hmaks - h(i)), RGB(255, 0, 0), BF
    If k < 8 Then
    Picture2.Line (i, hmaks)-(i + 1, hmaks - h(i)), RGB(0, 0, 0), B
    End If
Next i
Picture2.Refresh
End Sub

Private Sub Command3_Click()
Dim wr(80), wg(80), wb(80) As Integer
wr(1) = 0: wg(1) = 0: wb(1) = 0
wr(2) = 255: wg(2) = 0: wb(2) = 0
wr(3) = 0: wg(3) = 255: wb(3) = 0
wr(4) = 0: wg(4) = 0: wb(4) = 255
wr(5) = 255: wg(5) = 255: wb(5) = 0
wr(6) = 255: wg(6) = 0: wb(6) = 255
wr(7) = 0: wg(7) = 255: wb(7) = 255
wr(8) = 255: wg(8) = 255: wb(8) = 255
wr(9) = 128: wg(9) = 0: wb(9) = 0
wr(10) = 0: wg(10) = 128: wb(10) = 0
wr(11) = 0: wg(11) = 0: wb(11) = 128
wr(12) = 255: wg(12) = 128: wb(12) = 0
wr(13) = 128: wg(13) = 255: wb(13) = 0
wr(14) = 255: wg(14) = 0: wb(14) = 128
wr(15) = 128: wg(15) = 0: wb(15) = 255
wr(16) = 0: wg(16) = 255: wb(16) = 128
wr(17) = 0: wg(17) = 128: wb(17) = 255

For i = 1 To 17
    h(i) = 0
Next i
For i = 0 To nx - 1
    For j = 0 To ny - 1
        w = Picture1.Point(i, j)
        r = w And RGB(255, 0, 0)
        g = Int((w And RGB(0, 255, 0)) / 256)
        b = Int(Int((w And RGB(0, 0, 255)) / 256) / 256)
        dmin = 200000: indek = 0
        For m = 1 To 17
            d = ((r - wr(m)) ^ 2 + (g - wg(m)) ^ 2 + (b - wb(m)) ^ 2) ^ 0.5
            If d < dmin Then
                dmin = d
                indek = m
            End If
        Next m
        h(indek) = h(indek) + 1
    Next j
Next i
hmaks = 0
For i = 1 To 17
    If h(i) > hmaks Then hmaks = h(i)
Next i
Picture2.ScaleHeight = hmaks
Picture2.ScaleWidth = 17
Picture2.Cls
For i = 1 To 17
    Picture2.Line (i, hmaks)-(i - 1, hmaks - h(i)), RGB(wr(i), wg(i), wb(i)), BF
    Picture2.Line (i, hmaks)-(i - 1, hmaks - h(i)), RGB(0, 0, 0), B
Next i
Picture2.Refresh
End Sub

Private Function smax(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer) As Integer
smax = r
If g > smax Then smax = g
If b > smax Then smax = b
End Function

Private Function smin(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer) As Integer
smin = r
If g < smin Then smin = g
If b < smin Then smin = b
End Function

Private Sub Command4_Click()
For i = 0 To 89
    h(i) = 0
Next i
For i = 0 To nx - 1
    For j = 0 To ny - 1
        w = Picture1.Point(i, j)
        r = w And RGB(255, 0, 0)
        g = Int((w And RGB(0, 255, 0)) / 256)
        b = Int(Int((w And RGB(0, 0, 255)) / 256) / 256)
        ma = smax(r, g, b)
        mi = smin(r, g, b)
        d = ma - mi
        If d > 0 Then
            If ma = r Then k = 60 * (g - b) / d
            If ma = g Then k = 60 * ((b - r) / d + 2)
            If ma = b Then k = 60 * ((r - g) / d + 4)
            If k < 0 Then k = 360 - k
            indek = Int(90 * k / 360)
        Else
            indek = 0
        End If
        h(indek) = h(indek) + 1
    Next j
Next i
hmaks = 0
For i = 1 To 89
    If h(i) > hmaks Then hmaks = h(i)
Next i
Picture2.ScaleHeight = hmaks
Picture2.ScaleWidth = 90
Picture2.Cls
For i = 1 To 89
    Picture2.Line (i, hmaks)-(i - 1, hmaks - h(i)), vbRed, BF
    Picture2.Line (i, hmaks)-(i - 1, hmaks - h(i)), RGB(0, 0, 0), B
Next i
Picture2.Refresh
End Sub

Private Sub Form_Load()
nx = Picture1.ScaleWidth
ny = Picture1.ScaleHeight
End Sub
