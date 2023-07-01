Imports UltraScaler.xBRZ.Common
Namespace xBRZ.Blend
    Friend Module BlendInfo
        Public Function GetTopL(ByVal b As Char) As Char
            Return ChrW(AscW(b) And &H3)
        End Function

        Public Function GetTopR(ByVal b As Char) As Char
            Return ChrW((AscW(b) >> 2) And &H3)
        End Function

        Public Function GetBottomR(ByVal b As Char) As Char
            Return ChrW((AscW(b) >> 4) And &H3)
        End Function

        Public Function GetBottomL(ByVal b As Char) As Char
            Return ChrW((AscW(b) >> 6) And &H3)
        End Function

        Public Function SetTopL(ByVal b As Char, ByVal bt As Char) As Char
            Return ChrW(AscW(b) Or AscW(bt))
        End Function

        Public Function SetTopR(ByVal b As Char, ByVal bt As Char) As Char
            Return ChrW(AscW(b) Or (AscW(bt) << 2))
        End Function

        Public Function SetBottomR(ByVal b As Char, ByVal bt As Char) As Char
            Return ChrW(AscW(b) Or (AscW(bt) << 4))
        End Function

        Public Function SetBottomL(ByVal b As Char, ByVal bt As Char) As Char
            Return ChrW(AscW(b) Or (AscW(bt) << 6))
        End Function

        Public Function Rotate(ByVal b As Char, ByVal rotDeg As RotationDegree) As Char
            Dim l As Integer = CInt(rotDeg) << 1
            Dim r As Integer = 8 - l

            Return ChrW((AscW(b) << l) Or (AscW(b) >> r))
        End Function
    End Module
End Namespace
