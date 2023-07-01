Imports System
Imports System.Linq

Namespace xBRZ.Scalers
    Friend Module ScaleSize
        Private ReadOnly Scalers As IScaler() = {
            New Scaler2X(),
            New Scaler3X(),
            New Scaler4X(),
            New Scaler5X()
        }

        <System.Runtime.CompilerServices.Extension()>
        Public Function ToIScaler(ByVal scaleSize As Integer) As IScaler
            ' MJY: Need value checks to assure scaleSize is between 2-5 inclusive.
            Return Scalers.Single(Function(s) s.Scale = scaleSize)
        End Function
    End Module
End Namespace
