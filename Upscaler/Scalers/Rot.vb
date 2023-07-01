Imports System
Imports System.Linq

Namespace xBRZ.Scalers
    Friend Module Rot
        Public Const MaxRotations As Integer = 4 ' Number of 90 degree rotations
        Public Const MaxPositions As Integer = 9

        ' Cache the 4 rotations of the 9 positions, a to i.
        ' a = 0, b = 1, c = 2,
        ' d = 3, e = 4, f = 5,
        ' g = 6, h = 7, i = 8;
        Public ReadOnly R_ As Integer() = New Integer(MaxRotations * MaxPositions - 1) {}

        Sub New()
            Dim rotation = Enumerable.Range(0, MaxPositions).ToArray()
            Dim sideLength = CInt(Math.Sqrt(MaxPositions))
            For rot = 0 To MaxRotations - 1
                For pos = 0 To MaxPositions - 1
                    R_((pos * MaxRotations) + rot) = rotation(pos)
                Next
                rotation = rotation.RotateClockwise(sideLength)
            Next
        End Sub

        ' http://stackoverflow.com/a/38964502/294804
        <System.Runtime.CompilerServices.Extension>
        Private Function RotateClockwise(ByVal square1DMatrix As Integer(), Optional ByVal sideLength As Integer = 0) As Integer()
            Dim size = 0
            If sideLength > -1 Then size = CInt(Math.Sqrt(square1DMatrix.Length))
            Dim result = New Integer(square1DMatrix.Length - 1) {}

            For i = 0 To size - 1
                For j = 0 To size - 1
                    result(i * size + j) = square1DMatrix((size - j - 1) * size + i)
                Next
            Next

            Return result
        End Function
    End Module
End Namespace
