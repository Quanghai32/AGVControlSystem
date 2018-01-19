Imports System.Net.Http
Imports System.Xml.Linq

Module XmlReader
    Public ChartDataSet As DataSet
    Public ChartDataTable As New DataTable

    Public Sub ReadXmlData()
        If isNeedToReset Then
            ResetCounter()
        End If
        ReadHost()
        ReadEndDevices()
        ReadTextSource()
        ReadLineGroup()
        ReadAGVGroup()
        ReadPart()
        ReadAGV()
        ReadCross()
        ReadChart()
        ReadStartPoint()
        ReadParkPoint()
        ReadWorkingTime()
    End Sub

    Private Sub ReadTextSource()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\TextSource.xml")
        myDataTable = ds.Tables(0)

        If myDataTable.Rows.Count = 0 Then
            MessageBox.Show("Can not read setting for Text source. Please check again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End If
        TextList = New TextSource(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            Dim a = New RemainAnalyse() 'Depending on which method
            'Dim a = New RemainAnalyse()

            Dim path As String = myDataTable.Rows(i)("Path")
            TextList(i) = New TextSource(i, path, a) 'Dependency injection
        Next
    End Sub


    Private Sub ReadHost()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\HostXbee.xml")
        myDataTable = ds.Tables(0)

        If myDataTable.Rows.Count = 0 Then
            MessageBox.Show("Can not read setting for host Xbee. Please check again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End If
        HostXbee = New XBee(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            HostXbee(i) = New XBee()
            'HostXbee(i).Address = myDataTable.Rows(i)("Address")
            HostXbee(i).Address = Convert.ToInt32(myDataTable.Rows(i)("Address"), 16)
        Next
    End Sub

    Private Sub ReadEndDevices()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\EndDevices.xml")
        myDataTable = ds.Tables(0)

        If myDataTable.Rows.Count = 0 Then
            MessageBox.Show("Can not read setting for End Devices. Please check again", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End If
        EndDevicesArray = New EndDevices(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            EndDevicesArray(i) = New EndDevices()
            EndDevicesArray(i).Address = Convert.ToInt32(myDataTable.Rows(i)("Address"), 16)
            LinkDeviceAndXbee(EndDevicesArray(i), HostXbee(myDataTable.Rows(i)("Host Xbee")))
            EndDevicesArray(i).Host = (myDataTable.Rows(i)("Host Xbee"))
        Next
    End Sub
    Private Sub ReadLineGroup()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\LineGroup.xml")
        myDataTable = ds.Tables(0)

        LineGroupArray = New LineGroup(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            LineGroupArray(i).Name = myDataTable.Rows(i)("Name")
            LineGroupArray(i).MaxPart = 0
        Next
    End Sub

    Private Sub ReadAGVGroup()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\AGVGroup.xml")
        myDataTable = ds.Tables(0)

        AGVGroupArray = New AGVGroup(myDataTable.Rows.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            AGVGroupArray(i).Name = myDataTable.Rows(i)("Name")
            AGVGroupArray(i).MaxAGV = 0
        Next
    End Sub

    'Private Sub ReadPart()
    Private Sub ReadPart()
        '''''''''''*2_read status part was being suppling_''''''''''''''
        Dim isExistsRecordFile As Boolean = False
        Dim listRecordPart As List(Of String()) = New List(Of String())
        listRecordPart.Clear()
        Dim dtRecordPart As List(Of String) = New List(Of String)()
        If File.Exists("Record_Part.txt") Then
            isExistsRecordFile = True
            dtRecordPart = File.ReadLines("Record_Part.txt").ToList()
            For t As Integer = 0 To dtRecordPart.Count - 1
                Dim arrayRecordPart = dtRecordPart(t).Split(",")
                listRecordPart.Add(arrayRecordPart)
            Next
            File.Delete("Record_Part.txt")
        Else
            isExistsRecordFile = False
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim myDataTable As DataTable = New DataTable
        Dim endDevicesTB As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        Dim dss As DataSet = New DataSet

        ds.ReadXml(".\XML\Part.xml")
        myDataTable = ds.Tables(0)
        dss.ReadXml(".\XML\EndDevices.xml")
        endDevicesTB = dss.Tables(0)
        PartList = New List(Of CPart)

        Dim listIDEndDevices As List(Of Int16) = New List(Of Int16)
        listIDEndDevices.Clear()
        For tempID As Byte = 0 To endDevicesTB.Rows.Count - 1
            listIDEndDevices.Add(endDevicesTB.Rows(tempID)("Id"))
        Next
        Dim arrayIDEndDevices() As Integer = New Integer((listIDEndDevices.Count) - 1) {}

        For i As Byte = 0 To myDataTable.Rows.Count - 1
            Dim part As CPart = New CPart() With {.TIME_EMPTY = TimerChangePartSttValue, .TIME_FULL = TimerChangePartSttValue}
            part.index = myDataTable.Rows(i)("ID")
            part.Name = myDataTable.Rows(i)("Name")
            part.Enable = Boolean.Parse(myDataTable.Rows(i)("Enable"))
            part.TargetPoint = myDataTable.Rows(i)("TargetPoint")
            part.route = myDataTable.Rows(i)("Route")
            part.Text = Boolean.Parse(myDataTable.Rows(i)("Text"))
            part.TextSource = myDataTable.Rows(i)("TextSource")
            part.RemainStock = myDataTable.Rows(i)("RemainStock")
            part.priority = myDataTable.Rows(i)("Priority")
            part.group = myDataTable.Rows(i)("Group")
            part.SupplyCount = myDataTable.Rows(i)("count")
            part.target = myDataTable.Rows(i)("target")
            part.Status = True
            part.CycleTime = myDataTable.Rows(i)("CycleTime")
            part.Description = myDataTable.Rows(i)("Description")
            part.EmptyCount = myDataTable.Rows(i)("EmptyCount")
            part.X = myDataTable.Rows(i)("X")
            part.Y = myDataTable.Rows(i)("y")
            part.EndDevice = myDataTable.Rows(i)("EndDevices")

            ''''''''''''''''''''''''''''''_hien thi thu tu Part trong EndDevice_'''''''''''''''''''''''''
            For temp As Byte = 0 To listIDEndDevices.Count - 1
                If part.EndDevice = listIDEndDevices(temp) Then
                    arrayIDEndDevices(temp) = arrayIDEndDevices(temp) + 1
                    part.NumberInEnd = arrayIDEndDevices(temp)
                End If
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If part.Text = False Then
                ''''''''''''''*2_read status part was being suppling_''''''''''''''''''
                If isExistsRecordFile = True Then
                    Dim arrayPartRecord As String() = New String() {0, 0}
                    Dim isPartInPartBefore As Boolean = False
                    For temp As Integer = 0 To listRecordPart.Count - 1
                        If part.Name = listRecordPart(temp)(0) Then
                            arrayPartRecord(0) = listRecordPart(temp)(0)
                            arrayPartRecord(1) = listRecordPart(temp)(1)
                            isPartInPartBefore = True
                            Exit For
                        End If
                    Next
                    If isPartInPartBefore Then
                        part.AGVSupply = arrayPartRecord(1)
                        part.Status = False
                        isPartInPartBefore = False
                    Else
                        part.AGVSupply = ""
                    End If
                Else
                    part.AGVSupply = ""
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                part.parent = EndDevicesArray(part.EndDevice)
                EndDevicesArray(part.EndDevice).Parts.Add(part)
            Else
                ''''''''''''''*2_read status part was being suppling_''''''''''''''''''
                If isExistsRecordFile = True Then
                    Dim indexListRecordPart As List(Of Integer) = New List(Of Integer)()
                    For temp As Integer = 0 To listRecordPart.Count - 1
                        If part.Name = listRecordPart(temp)(0) Then
                            indexListRecordPart.Add(temp)
                        End If
                    Next
                    If indexListRecordPart.Count > 0 Then
                        part.AGVSupply = listRecordPart(indexListRecordPart(0))(1)
                        part.PalletNo = listRecordPart(indexListRecordPart(0))(2)
                        part.Status = False
                        For tempp As Integer = 1 To indexListRecordPart.Count - 1
                            Dim samePart As CPart = New CPart()
                            samePart = ClonePart(part)
                            samePart.AGVSupply = listRecordPart(indexListRecordPart(tempp))(1)
                            samePart.PalletNo = listRecordPart(indexListRecordPart(tempp))(2)
                            samePart.Status = False

                            samePart.parent = TextList(part.TextSource)
                            TextList(part.TextSource).TextPalletList.Add(samePart)
                            PalletList.Add(samePart)
                            TextList(part.TextSource).Init()
                        Next
                    End If
                Else
                    part.AGVSupply = ""
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                part.parent = TextList(part.TextSource)
                TextList(part.TextSource).TextPalletList.Add(part)
                PalletList.Add(part)
                TextList(part.TextSource).Init()
            End If

            PartList.Add(part)
        Next
    End Sub
    Private Sub ReadPartBka()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\Part.xml")
        myDataTable = ds.Tables(0)

        PartList = New List(Of CPart)

        'Khai bao bo nho cho part theo tung End
        For i As Byte = 0 To EndDevicesArray.Count - 1
            Dim NumPartOfEnd As Byte = 0
            For j As Byte = 0 To myDataTable.Rows.Count - 1                         'theo hàng
                Dim num As Byte
                If Not IsDBNull(myDataTable.Rows(j)("EndDevices")) Then             'neu database co du lieu
                    num = myDataTable.Rows(j)("EndDevices")                         'num = gia tri ghi trong cot EndDeivces tai hang thu i
                    If i.Equals(num) Then
                        NumPartOfEnd = NumPartOfEnd + 1
                    End If
                End If
            Next
            EndDevicesArray(i).AddPart(NumPartOfEnd)
        Next
        ''Khai bao bo nho cho part theo tung End
        'For i As Byte = 0 To EndDevicesArray.Count - 1
        '    Dim NumPartOfEnd As Byte = 0
        '    For j As Byte = 0 To myDataTable.Rows.Count - 1                         'theo hàng
        '        Dim num As Byte
        '        Dim text As Boolean
        '        If IsDBNull(myDataTable.Rows(j)("Text")) Then
        '            text = False
        '        End If
        '        text = Boolean.Parse(myDataTable.Rows(j)("Text"))
        '        If text = False Then
        '            If Not IsDBNull(myDataTable.Rows(j)("EndDevices")) Then             'neu database co du lieu
        '                num = myDataTable.Rows(j)("EndDevices")                         'num = gia tri ghi trong cot EndDeivces tai hang thu i
        '                If i.Equals(num) Then
        '                    NumPartOfEnd = NumPartOfEnd + 1
        '                End If
        '            End If
        '        End If
        '    Next
        '    EndDevicesArray(i).AddPart(NumPartOfEnd)
        'Next

        ''Khai bao bo nho cho part theo tung End
        'For i As Byte = 0 To TextList.Count - 1
        '    Dim NumPartOfText As Byte = 0
        '    For j As Byte = 0 To myDataTable.Rows.Count - 1                         'theo hàng
        '        Dim text As Boolean
        '        Dim num As Byte
        '        If Not IsDBNull(myDataTable.Rows(j)("Text")) Then
        '            text = False
        '        End If
        '        text = Boolean.Parse(myDataTable.Rows(j)("Text"))
        '        If text = True Then
        '            If Not IsDBNull(myDataTable.Rows(j)("TextSource")) Then             'neu database co du lieu
        '                num = myDataTable.Rows(j)("TextSource")
        '                If i.Equals(num) Then
        '                    NumPartOfText = NumPartOfText + 1
        '                End If
        '            End If
        '        End If

        '    Next
        '    TextList(i).AddPart(NumPartOfText)
        'Next
        'Read Part table
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            Dim num As Byte
            If Not IsDBNull(myDataTable.Rows(i)("EndDevices")) Then             'neu database co du lieu
                num = myDataTable.Rows(i)("EndDevices")
                For j As Byte = 0 To EndDevicesArray(num).CollectPart_PerEnd.Count          'theo cột
                    If EndDevicesArray(num).Parts(j).Name = "" Then
                        EndDevicesArray(num).Parts(j).Name = myDataTable.Rows(i)("Name")
                        If IsDBNull(myDataTable.Rows(i)("Enable")) Then
                            EndDevicesArray(num).Parts(j).Enable = False
                        Else
                            EndDevicesArray(num).Parts(j).Enable = myDataTable.Rows(i)("Enable")
                        End If
                        EndDevicesArray(num).Parts(j).index = myDataTable.Rows(i)("ID")
                        EndDevicesArray(num).Parts(j).priority = myDataTable.Rows(i)("Priority")
                        EndDevicesArray(num).Parts(j).TargetPoint = myDataTable.Rows(i)("TargetPoint")
                        EndDevicesArray(num).Parts(j).group = myDataTable.Rows(i)("Group")
                        EndDevicesArray(num).Parts(j).SupplyCount = myDataTable.Rows(i)("count")
                        EndDevicesArray(num).Parts(j).target = myDataTable.Rows(i)("target")
                        EndDevicesArray(num).Parts(j).route = myDataTable.Rows(i)("Route")
                        EndDevicesArray(num).Parts(j).Status = True
                        EndDevicesArray(num).Parts(j).EndDevice = num
                        EndDevicesArray(num).Parts(j).CycleTime = myDataTable.Rows(i)("CycleTime")
                        EndDevicesArray(num).Parts(j).Description = myDataTable.Rows(i)("Description")
                        EndDevicesArray(num).Parts(j).EmptyCount = myDataTable.Rows(i)("EmptyCount")
                        EndDevicesArray(num).Parts(j).X = myDataTable.Rows(i)("X")
                        EndDevicesArray(num).Parts(j).Y = myDataTable.Rows(i)("y")
                        LineGroupArray(EndDevicesArray(num).Parts(j).group).MaxPart += 1
                        If IsNothing(LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart) Then
                            LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart = New Collection
                        End If
                        LineGroupArray(EndDevicesArray(num).Parts(j).group).ChildPart.Add(EndDevicesArray(num).Parts(j))
                        PartList.Add(EndDevicesArray(num).Parts(j))
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub ReadAGV()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\AGV.xml")
        myDataTable = ds.Tables(0)

        AGVList = New List(Of AGV)
        'Make copy
        preAGVStatusArray = New struct_AGVStoreStatus(myDataTable.Rows.Count - 1) {}
        AGVnPART = New Boolean(myDataTable.Rows.Count - 1, PartList.Count - 1) {}
        For i As Byte = 0 To myDataTable.Rows.Count - 1
            For j As Byte = 0 To PartList.Count - 1
                AGVnPART(i, j) = False
            Next
        Next

        For i As Byte = 0 To myDataTable.Rows.Count - 1
            AGVList.Add(New AGV(myDataTable.Rows(i)("Name"), Convert.ToInt32(myDataTable.Rows(i)("Address"), 16)))
            preAGVStatusArray(i).connecting_time = Now
            preAGVStatusArray(i).status_time = Now
            preAGVStatusArray(i).working_time = Now
            preAGVStatusArray(i).Enable_time = Now
            preAGVStatusArray(i).Shutdown_time = Now
            preAGVStatusArray(i).TimeAGVPowerOn_value = 0
            If IsDBNull(myDataTable.Rows(i)("Enable")) Then
                AGVList(i).Enable = False
            Else
                AGVList(i).Enable = myDataTable.Rows(i)("Enable")
            End If
            AGVList(i).group = myDataTable.Rows(i)("Group")
            AGVList(i).index = i ' myDataTable.Rows(i)("id")
            AGVList(i).HostControl = myDataTable.Rows(i)("Host Xbee")
            AGVList(i).SupplyCount = myDataTable.Rows(i)("Count")
            AGVList(i)._TIME_FREE = TimerFree
            AGVGroupArray(AGVList(i).group).MaxAGV += 1
            If IsNothing(AGVGroupArray(AGVList(i).group).ChildAGV) Then
                AGVGroupArray(AGVList(i).group).ChildAGV = New Collection
            End If
            AGVGroupArray(AGVList(i).group).ChildAGV.Add(AGVList(i))
            LinkDeviceAndXbee(AGVList(i), HostXbee(myDataTable.Rows(i)("Host Xbee")))
            setAGVSupply(i, myDataTable.Rows(i)("Part"))
        Next

    End Sub
    Private Sub ReadCross()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\CrossTable.xml")
        myDataTable = ds.Tables(0)

        MAX_CROSS = myDataTable.Rows.Count
        CrossArray = New CrossStruct(myDataTable.Rows.Count - 1) {}
        For CrossNumber As Byte = 0 To myDataTable.Rows.Count - 1
            Dim CrossPosArray() As Integer = New Integer(MAX_POS_IN_CROSS - 1) {}
            For CrossPosNum As Byte = 1 To MAX_POS_IN_CROSS
                'If myDataTable.Rows(CrossNumber)(CrossPosNum.ToString).GetType = GetType(Integer) Then
                CrossPosArray(CrossPosNum - 1) = myDataTable.Rows(CrossNumber)(CrossPosNum.ToString)
                'Else : Exit For
                'End If
            Next
            InitSingleCross(CrossArray(CrossNumber), CrossPosArray)
        Next
        initCrossVar()
    End Sub

    Private Sub ReadChartBka()
        ChartDataSet = New DataSet()
        ChartDataTable = New DataTable()
        ChartDataSet.ReadXml(".\XML\Chart.xml")
        ChartDataTable = ChartDataSet.Tables("chart")

        If ChartDataTable.Rows.Count < AGVList.Count Then 'when add new agv
            While ChartDataTable.Rows.Count < AGVList.Count
                Dim newRow As DataRow = ChartDataTable.NewRow()
                newRow(0) = ChartDataTable.Rows.Count
                For i As Byte = 1 To 12
                    newRow(i) = 0
                Next
                ChartDataTable.Rows.Add(newRow)
            End While
            ChartResetXML()
        ElseIf ChartDataTable.Rows.Count > AGVList.Count Then 'when delete agv
            While ChartDataTable.Rows.Count > AGVList.Count
                ChartDataTable.Rows.RemoveAt(ChartDataTable.Rows.Count - 1)
            End While
            ChartResetXML()
        End If

        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            ChartDataTable.Rows.Item(i)(1) = AGVList(i).Name
        Next

        Dim MaxTime As Double = 0
        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            Dim totalTime As Double = 0
            For j As Byte = 2 To 12
                totalTime = totalTime + ChartDataTable.Rows.Item(i)(j)
            Next
            If MaxTime < totalTime Then MaxTime = totalTime
        Next
        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            Dim notDisconnectTime As Double = 0
            For j As Byte = 2 To 11
                notDisconnectTime += ChartDataTable.Rows.Item(i)(j)
            Next
            ChartDataTable.Rows.Item(i)(12) = MaxTime - notDisconnectTime
        Next

        'For agvNum As Integer = 0 To AGVList.Count - 1
        '    Dim agv = AGVList(agvNum).Name
        '    'Dim checkContains As Boolean = tempChartDataTable.AsEnumerable().Any(Function(row) agv = row.Field(Of [String])("Name"))
        '    Dim foundRows() As Data.DataRow
        '    foundRows = tempChartDataSet.Tables("Chart").[Select]("Name Like '" + agv + "'")
        '    ChartDataTable.Rows.Add(foundRows)
        'Next

    End Sub

    Private Sub CreateChart(ByRef ChartDataTable As DataTable)
        ChartDataTable = New DataTable
        ChartDataTable.Columns.Add("Id", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Name")
        ChartDataTable.Columns.Add("EMG", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Safety", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Stop", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Out line", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Battery empty", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("No cart", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Normal", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Free", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Pole error", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Disconnect", System.Type.GetType("System.Double"))
        ChartDataTable.Columns.Add("Shutdown", System.Type.GetType("System.Double"))
        ChartDataTable.TableName = "Chart"
    End Sub

    Private Sub ReadChart()
        ChartDataSet = New DataSet()
        ChartDataTable = New DataTable()
        Dim tempChartDataSet = New DataSet()
        Dim tempChartDataTable As DataTable = New DataTable()

        ChartDataSet.ReadXml(".\XML\Chart.xml")
        tempChartDataSet.ReadXml(".\XML\Chart.xml")

        ChartDataTable = ChartDataSet.Tables("chart")
        tempChartDataTable = tempChartDataSet.Tables("chart")

        If IsNothing(ChartDataTable) Then
            CreateChart(ChartDataTable)
            CreateChart(tempChartDataTable)
        End If
        While ChartDataTable.Rows.Count > 0
            ChartDataTable.Rows.RemoveAt(ChartDataTable.Rows.Count - 1)
        End While

        'check if agv is not contain in chart
        For agvNum As Integer = 0 To AGVList.Count - 1
            Dim agv = AGVList(agvNum).Name
            Dim contain As Boolean = False
            Dim newRow As DataRow = ChartDataTable.NewRow()
            newRow(0) = ChartDataTable.Rows.Count
            newRow(1) = agv

            For chartNum As Integer = 0 To tempChartDataTable.Rows.Count - 1
                If tempChartDataTable.Rows.Item(chartNum)(1) = agv Then 'if chart already contain AGV in agvlist
                    For i As Byte = 2 To 12
                        newRow(i) = tempChartDataTable.Rows.Item(chartNum)(i)
                    Next
                    contain = True
                    Exit For
                End If
            Next
            If contain = False Then 'if not contail --> add with all value = 0
                For i As Byte = 2 To 12
                    newRow(i) = 0
                Next
            End If
            ChartDataTable.Rows.Add(newRow)
        Next

        If isNeedToReset Then
            Return
        End If

        'check if chart have agv was not contain in agvlist
        For chartNum As Integer = 0 To tempChartDataTable.Rows.Count - 1
            Dim agv = tempChartDataTable.Rows.Item(chartNum)(1)
            Dim contain As Boolean = False
            For agvNum As Integer = 0 To AGVList.Count - 1
                If AGVList(agvNum).Name = agv Then 'if agvlist already contain agv in chart
                    contain = True
                    Exit For
                End If
            Next
            If contain = False Then
                Dim newRow As DataRow = ChartDataTable.NewRow()
                newRow(0) = ChartDataTable.Rows.Count
                For i As Byte = 1 To 12
                    newRow(i) = tempChartDataTable.Rows.Item(chartNum)(i)
                Next
                ChartDataTable.Rows.Add(newRow)
            End If
        Next

        Dim MaxTime As Double = 0
        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            Dim totalTime As Double = 0
            For j As Byte = 2 To 12
                totalTime = totalTime + ChartDataTable.Rows.Item(i)(j)
            Next
            If MaxTime < totalTime Then MaxTime = totalTime
        Next
        For i As Byte = 0 To ChartDataTable.Rows.Count - 1
            Dim notShutdownTime As Double = 0
            For j As Byte = 2 To 11
                notShutdownTime += ChartDataTable.Rows.Item(i)(j)
            Next
            ChartDataTable.Rows.Item(i)(12) = MaxTime - notShutdownTime
        Next
    End Sub

    Private Sub ReadStartPoint()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\StartPoint.xml")
        myDataTable = ds.Tables(0)

        StartPoint = New Integer(myDataTable.Rows.Count - 1) {}
        For SPnum As Byte = 0 To myDataTable.Rows.Count - 1
            StartPoint(SPnum) = myDataTable.Rows(SPnum)(1)
        Next
    End Sub
    Private Sub ReadParkPoint()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\ParkPoint.xml")
        myDataTable = ds.Tables(0)

        If myDataTable.Rows.Count > 0 Then
            ParkPointArray = New Integer(1, myDataTable.Rows.Count - 1) {}
            For PPNum As Byte = 0 To myDataTable.Rows.Count - 1
                ParkPointArray(0, PPNum) = myDataTable.Rows(PPNum)("First")
                ParkPointArray(1, PPNum) = myDataTable.Rows(PPNum)("Second")
            Next
        End If
    End Sub
    Private Sub ReadWorkingTime()
        Dim myDataTable As DataTable = New DataTable
        Dim ds As DataSet = New DataSet
        ds.ReadXml(".\XML\WorkingTime.xml")
        myDataTable = ds.Tables(0)

        If myDataTable.Rows.Count > 0 Then
            WorkingTimeArray = New struct_Workingtime(myDataTable.Rows.Count - 1) {}
            For PPNum As Byte = 0 To myDataTable.Rows.Count - 1
                WorkingTimeArray(PPNum).StartTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("BeginTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("BeginTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StartMorningTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StartMorTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StartMorTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopMorningTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StopMorTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StopMorTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StartLunchTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StartLunTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StartLunTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopLunchTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StopLunTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StopLunTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StartAfterTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StartAftTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StartAftTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopAfterTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("StopAftTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("StopAftTime"), DateTime).Minute, 0)
                WorkingTimeArray(PPNum).StopTime = New DateTime(2015, 1, 1, CType(myDataTable.Rows(PPNum)("EndTime"), DateTime).Hour, CType(myDataTable.Rows(PPNum)("EndTime"), DateTime).Minute, 0)
            Next
        End If
    End Sub



    Private Sub ResetCounter()
        ResetPartCounter()
        ResetAGVCounter()
    End Sub
    Private Sub ResetPartCounter()
        'Dim cmdText As String = "UPDATE PART SET COUNT=0"
        'Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
        'sqlcmd.ExecuteNonQuery()
        Dim doc = XElement.Load(".\XML\Part.xml")
        Dim target = doc.Elements("Part")

        For Each o As XElement In target
            o.Elements("Count").Value = 0
            o.Element("EmptyCount").Value = 0
        Next
        doc.Save(".\XML\Part.xml")
    End Sub
    Private Sub ResetAGVCounter()
        'Dim cmdText As String = "UPDATE AGV SET COUNT=0"
        'Dim sqlcmd = New SqlCommand(cmdText, SQLcon)
        'sqlcmd.ExecuteNonQuery()
        Dim doc = XElement.Load(".\XML\AGV.xml")
        Dim target = doc.Elements("AGV")

        For Each o As XElement In target
            o.Elements("Count").Value = 0
        Next
        doc.Save(".\XML\AGV.xml")
    End Sub

    Public Sub MapUpdate()
        Static X() As Integer = New Integer(MapPartList.Count - 1) {}
        For i As Byte = 0 To MapPartList.Count - 1
            If X(i) <> MapPartList(i).X Then
                SaveXml("Part", i, "X", MapPartList(i).X.ToString)
                X(i) = MapPartList(i).X
            End If
        Next

        Static Y() As Integer = New Integer(MapPartList.Count - 1) {}
        For i As Byte = 0 To MapPartList.Count - 1
            If Y(i) <> MapPartList(i).Y Then
                SaveXml("Part", i, "Y", MapPartList(i).Y.ToString)
                Y(i) = MapPartList(i).Y
            End If
        Next
    End Sub

    Public Sub SaveXml(ByVal table As String, ByVal id As Integer, ByVal element As String, ByVal value As String)
        Dim doc = XElement.Load(".\XML\" + table + ".xml")
        Dim target = doc.Elements(table).
            [Single](Function(u) u.Element("Id").Value = id.ToString())

        target.Element(element).Value = value
        doc.Save(".\XML\" + table + ".xml")
    End Sub


    Public Sub ChartUpdateXml()
        ChartDataTable.WriteXml(".\XML\Chart.xml")

        Static PartCounter() As Integer = New Integer(PartList.Count - 1) {}
        For i As Byte = 0 To PartList.Count - 1
            If PartCounter(i) <> PartList(i).SupplyCount Then
                'Dim cmdText As String = "UPDATE PART SET COUNT=" + PartList(i).SupplyCount.ToString + " WHERE Id=" + i.ToString
                SaveXml("Part", i, "Count", PartList(i).SupplyCount.ToString)
                PartCounter(i) = PartList(i).SupplyCount
            End If
        Next

        Static EmptyCounter() As Integer = New Integer(PartList.Count - 1) {}
        For i As Byte = 0 To PartList.Count - 1
            If EmptyCounter(i) <> PartList(i).EmptyCount Then
                'Dim cmdText As String = "UPDATE PART SET EMPTYCOUNT=" + PartList(i).EmptyCount.ToString + " WHERE Id=" + i.ToString
                SaveXml("Part", i, "EmptyCount", PartList(i).EmptyCount.ToString)
                EmptyCounter(i) = PartList(i).EmptyCount
            End If
        Next

        Static AGVCounter() As Integer = New Integer(AGVList.Count - 1) {}
        For i As Byte = 0 To AGVList.Count - 1
            If AGVCounter(i) <> AGVList(i).SupplyCount Then
                'Dim cmdText As String = "UPDATE AGV SET COUNT=" + AGVList(i).SupplyCount.ToString + " WHERE Id=" + i.ToString
                SaveXml("AGV", i, "Count", AGVList(i).SupplyCount.ToString)
                AGVCounter(i) = AGVList(i).SupplyCount
            End If
        Next

        FCheckTime(DayName, ShipName)
        If DayName <> "" Then
            Dim json As String = ""
            Dim fileName As String = BlockName + "_" + DayName + "_" + ShipName + ".txt"
            Dim path As String = "./Performance/" + fileName
            DataTableToJson(ChartDataTable, json)
            File.WriteAllText(path, json)
        End If

        GenerateAgvPerformanceObject()
    End Sub

    Public Sub FCheckTime(ByRef day As String, ByRef ship As String)
        Dim time As DateTime = Now
        If time.TimeOfDay >= WorkingTimeArray(0).StartTime.TimeOfDay And time.TimeOfDay <= WorkingTimeArray(0).StopTime.TimeOfDay Then
            day = time.ToString("yyyyMMdd")
            ship = "Day"
        ElseIf time.TimeOfDay >= WorkingTimeArray(1).StartTime.TimeOfDay Then
            day = time.ToString("yyyyMMdd")
            ship = "Night"
        ElseIf time.TimeOfDay <= WorkingTimeArray(1).StopTime.TimeOfDay Then
            day = time.AddDays(-1).ToString("yyyyMMdd")
            ship = "Night"
        Else
            day = ""
            ship = ""
        End If
    End Sub

    Public Sub GenerateAgvPerformanceObject()
        Dim listAgv As List(Of ClsAgvPerformance) = New List(Of ClsAgvPerformance)()
        For count As Integer = 0 To ChartDataTable.Rows.Count() - 1
            Dim agv = New ClsAgvPerformance()
            agv.Id = Int32.Parse(ChartDataTable.Rows(count).Item(0).ToString())
            agv.Name = ChartDataTable.Rows(count).Item(1).ToString()
            agv.EGM = Double.Parse(ChartDataTable.Rows(count).Item(2).ToString())
            agv.Safety = Double.Parse(ChartDataTable.Rows(count).Item(3).ToString())
            agv.StopByCard = Double.Parse(ChartDataTable.Rows(count).Item(4).ToString())
            agv.OutLine = Double.Parse(ChartDataTable.Rows(count).Item(5).ToString())
            agv.BatteryLow = Double.Parse(ChartDataTable.Rows(count).Item(6).ToString())
            agv.NoCart = Double.Parse(ChartDataTable.Rows(count).Item(7).ToString())
            agv.Normal = Double.Parse(ChartDataTable.Rows(count).Item(8).ToString())
            agv.Free = Double.Parse(ChartDataTable.Rows(count).Item(9).ToString())
            agv.PoleErr = Double.Parse(ChartDataTable.Rows(count).Item(10).ToString())
            agv.Disconnect = Double.Parse(ChartDataTable.Rows(count).Item(11).ToString())
            agv.Shutdown = Double.Parse(ChartDataTable.Rows(count).Item(12).ToString())
            listAgv.Add(agv)
        Next
        'Task.Run(Sub() postProducts(listAgv))
    End Sub

    Private Async Sub postProducts(products As List(Of ClsAgvPerformance))
        Dim client As New HttpClient()
        httpResponse = Await client.PutAsJsonAsync(Of List(Of ClsAgvPerformance))(ServerName + "/Api/Agv/UpdatePerformance", products)
        If Not httpResponse.IsSuccessStatusCode Then
            Debug.Print("ERROR:  Products Not Posted." + httpResponse.ReasonPhrase)
        End If
        products = Await httpResponse.Content.ReadAsAsync(Of List(Of ClsAgvPerformance))()

    End Sub
    Public Sub ChartResetXML()
        Dim time As DateTime = Now
        Dim day As String = ""
        Dim ShipName As String = ""
        FCheckTime(day, ShipName)

        If day <> "" Then
            If File.Exists("./Performance/" + BlockName + "_" + day + "_" + ShipName + ".txt") Then
                MessageBox.Show("Bạn không thể xóa dữ liệu trong thời gian sản xuất" + vbCrLf + day + "_" + ShipName, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        For AGVNum As Byte = 0 To AGVList.Count - 1
            For column As Byte = 2 To 12
                ChartDataTable.Rows(AGVNum)(column) = 0
            Next
        Next
        ChartDataTable.WriteXml(".\XML\Chart.xml")
    End Sub

    ''' <summary>
    ''' Link AGV or End Devices and Xbee together
    ''' </summary>
    ''' <param name="userAGV">AGV object</param>
    ''' <param name="userXbee">Xbee which receive data from AGV</param>
    ''' <remarks></remarks>
    Public Sub LinkDeviceAndXbee(ByVal userAGV As AGV, ByVal userXbee As XBee)
        userXbee.ChildComponent.Add(userAGV)
        userAGV.myXbee = userXbee
    End Sub
    ''' <summary>
    ''' Link AGV or End Devices and Xbee together
    ''' </summary>
    ''' <param name="userEndDevices">End Devices</param>
    ''' <param name="userXbee">Xbee which receive data from AGV</param>
    ''' <remarks></remarks>
    Public Sub LinkDeviceAndXbee(ByVal userEndDevices As EndDevices, ByVal userXbee As XBee)
        userXbee.ChildComponent.Add(userEndDevices)
        userEndDevices.myXbee = userXbee
    End Sub

End Module
