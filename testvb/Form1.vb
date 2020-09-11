Public Class Window

    Dim savetf As Boolean = True   ' 保存後に変更が加えられたかの真偽 (T: 未変更 F: 変更)

    ' ====== プログラム起動 ======

    Private Sub Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        My.Settings.Reload()

        ' workspaceのImageオブジェクトをセット
        canvas = New Bitmap(workspace.Width, workspace.Height)

        ' workspace透過
        workspace.BackColor = TransparencyKey

        ' ラジオボタンの外観をボタンに見せかける
        start_finish_rb.Appearance = Appearance.Button
        normarl_process_rb.Appearance = Appearance.Button
        def_process_rb.Appearance = Appearance.Button
        segmentation_rb.Appearance = Appearance.Button
        branch_rb.Appearance = Appearance.Button
        ioput_rb.Appearance = Appearance.Button
        loop_head_rb.Appearance = Appearance.Button
        loop_bottom_rb.Appearance = Appearance.Button
        connector_rb.Appearance = Appearance.Button
        line_rb.Appearance = Appearance.Button
        pen_rb.Appearance = Appearance.Button
        eraser_rb.Appearance = Appearance.Button

        ' Checked値と外観を手動で設定できるようにTrueにする
        start_finish_rb.AutoCheck = True
        normarl_process_rb.AutoCheck = True
        def_process_rb.AutoCheck = True
        segmentation_rb.AutoCheck = True
        branch_rb.AutoCheck = True
        ioput_rb.AutoCheck = True
        loop_head_rb.AutoCheck = True
        loop_bottom_rb.AutoCheck = True
        connector_rb.AutoCheck = True
        line_rb.AutoCheck = True
        pen_rb.AutoCheck = True
        eraser_rb.AutoCheck = True

        ' 背景画像を"Stretch"または"Zoom"に設定
        start_finish_rb.BackgroundImageLayout = ImageLayout.Stretch
        normarl_process_rb.BackgroundImageLayout = ImageLayout.Stretch
        def_process_rb.BackgroundImageLayout = ImageLayout.Stretch
        segmentation_rb.BackgroundImageLayout = ImageLayout.Stretch
        branch_rb.BackgroundImageLayout = ImageLayout.Stretch
        ioput_rb.BackgroundImageLayout = ImageLayout.Stretch
        loop_head_rb.BackgroundImageLayout = ImageLayout.Stretch
        loop_bottom_rb.BackgroundImageLayout = ImageLayout.Stretch
        connector_rb.BackgroundImageLayout = ImageLayout.Zoom
        line_rb.BackgroundImageLayout = ImageLayout.Zoom
        pen_rb.BackgroundImageLayout = ImageLayout.Stretch
        eraser_rb.BackgroundImageLayout = ImageLayout.Stretch

        ' 開始-終了記号をフォーカス
        ActiveControl = start_finish_rb

        ' フォントサイズ10をデフォルト値
        font_size.SelectedIndex = 1

    End Sub

    '=============================


    ' ===== プログラム終了 =====

    Private Sub Window_Close(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        ' 保存後変更が加えられていたら
        If savetf = False Then

            Dim msgresult As DialogResult

            ' 確認メッセージ表示
            msgresult = MessageBox.Show("変更を保存しますか？", "プログラムの終了", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

            ' Yesボタン押下->データ書込み後、終了
            If msgresult = DialogResult.Yes Then

                File_write_save2()

            ElseIf msgresult = DialogResult.No Then ' Noボタン押下->終了



            Else    ' Cancelボタン押下

                e.Cancel = True ' プログラムの終了を中止

            End If

        End If

    End Sub

    ' ==========================


    ' ====== フローチャート記号の生成 ======

    Private start_finish As PictureBox      ' 開始-終了記号
    Private normal_process As PictureBox    ' 処理記号
    Private def_process As PictureBox       ' 定義済み処理記号
    Private segmentation As PictureBox      ' 準備記号
    Private branch As PictureBox            ' 分岐記号
    Private ioput As PictureBox             ' 入出力記号
    Private loop_head As PictureBox         ' 反復(上)記号
    Private loop_bottom As PictureBox       ' 反復(下)記号
    Private connector As PictureBox         ' 結合子
    Private pen As TextBox                  ' テキスト
    Private eraser As PictureBox            ' 消去

    Dim x_init As Integer   ' 生成位置(X座標)
    Dim y_init As Integer   ' 生成位置(Y座標)

    Dim count As String = 0             ' コントロール名に付加する番号
    Dim Ctrl_name_list(100) As String   ' コントロール名リスト

    Private Sub Workspace_Click(sender As Object, e As MouseEventArgs) Handles workspace.Click

        ' ピクチャボックスのインスタンスを作成し、プロパティを設定する
        SuspendLayout()

        ' クリックされた位置に生成
        x_init = e.X - 41.8295
        y_init = e.Y - 18.647

        ' 分岐用線引き処理中でない時
        If bh(0) = vbNull Then

            count += 1

            ' 開始-終了記号
            If start_finish_rb.Checked Then

                ' プロパティ設定
                start_finish = New PictureBox With {
                    .Image = My.Resources.stafin2,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_start_finish" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler start_finish.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler start_finish.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler start_finish.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler start_finish.MouseClick, AddressOf Ctrl_Delete
                AddHandler start_finish.MouseClick, AddressOf Line_Write
                AddHandler start_finish.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(start_finish)
                start_finish.BringToFront()

                CtrlNum = 0
                Ctrl_name_list(count - 1) = start_finish.Name

            End If

            ' 処理記号
            If normarl_process_rb.Checked Then

                ' プロパティ設定
                normal_process = New PictureBox With {
                    .Image = My.Resources.syori1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_normal_process" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler normal_process.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler normal_process.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler normal_process.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler normal_process.MouseClick, AddressOf Ctrl_Delete
                AddHandler normal_process.MouseClick, AddressOf Line_Write
                AddHandler normal_process.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(normal_process)
                normal_process.BringToFront()

                CtrlNum = 1
                Ctrl_name_list(count - 1) = normal_process.Name

            End If

            ' 定義済み処理
            If def_process_rb.Checked Then

                ' プロパティ設定
                def_process = New PictureBox With {
                    .Image = My.Resources.tesyori1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_def_process" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler def_process.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler def_process.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler def_process.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler def_process.MouseClick, AddressOf Ctrl_Delete
                AddHandler def_process.MouseClick, AddressOf Line_Write
                AddHandler def_process.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(def_process)
                def_process.BringToFront()

                CtrlNum = 2
                Ctrl_name_list(count - 1) = def_process.Name

            End If

            ' 準備記号
            If segmentation_rb.Checked Then

                ' プロパティ設定
                segmentation = New PictureBox With {
                    .Image = My.Resources.seg1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_segmentation" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler segmentation.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler segmentation.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler segmentation.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler segmentation.MouseClick, AddressOf Ctrl_Delete
                AddHandler segmentation.MouseClick, AddressOf Line_Write
                AddHandler segmentation.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(segmentation)
                segmentation.BringToFront()

                CtrlNum = 3
                Ctrl_name_list(count - 1) = segmentation.Name

            End If

            ' 分岐記号
            If branch_rb.Checked Then

                ' プロパティ設定
                branch = New PictureBox With {
                    .Image = My.Resources.handan1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_branch" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler branch.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler branch.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler branch.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler branch.MouseClick, AddressOf Ctrl_Delete
                AddHandler branch.MouseClick, AddressOf Line_Write
                AddHandler branch.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(branch)
                branch.BringToFront()

                CtrlNum = 4
                Ctrl_name_list(count - 1) = branch.Name

            End If

            ' 入出力記号
            If ioput_rb.Checked Then

                ' プロパティ設定
                ioput = New PictureBox With {
                    .Image = My.Resources.inout1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_ioput" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler ioput.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler ioput.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler ioput.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler ioput.MouseClick, AddressOf Ctrl_Delete
                AddHandler ioput.MouseClick, AddressOf Line_Write
                AddHandler ioput.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(ioput)
                ioput.BringToFront()

                CtrlNum = 5
                Ctrl_name_list(count - 1) = ioput.Name

            End If

            ' 反復(上)記号
            If loop_head_rb.Checked Then

                ' プロパティ設定
                loop_head = New PictureBox With {
                    .Image = My.Resources.head1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_loop_head" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler loop_head.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler loop_head.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler loop_head.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler loop_head.MouseClick, AddressOf Ctrl_Delete
                AddHandler loop_head.MouseClick, AddressOf Line_Write
                AddHandler loop_head.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(loop_head)
                loop_head.BringToFront()

                CtrlNum = 6
                Ctrl_name_list(count - 1) = loop_head.Name

            End If

            ' 反復(下)記号
            If loop_bottom_rb.Checked Then

                ' プロパティ設定
                loop_bottom = New PictureBox With {
                    .Image = My.Resources.bottom1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_loop_bottom" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler loop_bottom.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler loop_bottom.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler loop_bottom.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler loop_bottom.MouseClick, AddressOf Ctrl_Delete
                AddHandler loop_bottom.MouseClick, AddressOf Line_Write
                AddHandler loop_bottom.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(loop_bottom)
                loop_bottom.BringToFront()

                CtrlNum = 7
                Ctrl_name_list(count - 1) = loop_bottom.Name

            End If

            ' 結合子
            If connector_rb.Checked Then

                ' プロパティ設定
                connector = New PictureBox With {
                    .Image = My.Resources.ketugou1,
                    .Location = New Point(x_init, y_init),
                    .Name = "name_connector" + count,
                    .Size = New Size(132, 60),
                    .TabIndex = 1,
                    .TabStop = False,
                    .SizeMode = ImageLayout.Zoom
                }

                ' イベントハンドラに関連付け
                AddHandler connector.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler connector.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler connector.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler connector.MouseClick, AddressOf Ctrl_Delete
                AddHandler connector.MouseClick, AddressOf Line_Write
                AddHandler connector.MouseClick, AddressOf Text_In_Pic

                ' workspaceに描写
                workspace.Controls.Add(connector)
                connector.BringToFront()

                CtrlNum = 8
                Ctrl_name_list(count - 1) = connector.Name

            End If

            ' テキスト
            If pen_rb.Checked Then

                ' プロパティ設定
                pen = New TextBox With {
                    .Location = New Point(x_init, y_init),
                    .Name = "name_pen" + count,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Font = New Font("MS UI Gothic", fontsize),
                    .Multiline = True,
                    .ImeMode = ImeMode.On
                }

                ' イベントハンドラに関連付け
                AddHandler pen.MouseDown, AddressOf Ctrl_MouseDown
                AddHandler pen.MouseMove, AddressOf Ctrl_MouseMove
                AddHandler pen.MouseUp, AddressOf Ctrl_MouseUp
                AddHandler pen.KeyDown, AddressOf Text_Border_Edit
                AddHandler pen.MouseClick, AddressOf Ctrl_Delete

                ' workspaceに描写
                workspace.Controls.Add(pen)
                pen.BringToFront()

                CtrlNum = 9
                Ctrl_name_list(count - 1) = pen.Name

            End If

            ' 消去ツール
            If eraser_rb.Checked Then

                mxy = workspace.PointToClient(Cursor.Position)  ' マウスカーソルの位置
                Line_Delete()

            End If

            ReDim Preserve Ctrl_name_list(count)

            ' 位置情報の保存
            numlist.Add(CtrlNum)
            xlist.Add(x_init)
            ylist.Add(y_init)

            index_xy += 1

            ' 自動整列の基準定義
            If xlist(index_xy - 1) >= 0 And ylist(index_xy - 1) >= 0 And xlist(index_xy - 1) <= workspace.Width And ylist(index_xy - 1) <= 100 And line_rb.Checked = False Then

                Auto_alignment()

            End If

            savetf = False  ' 変更状態にする

        Else    ' 分岐用線引き処理中の時

            mxy = workspace.PointToClient(Cursor.Position)  ' マウスカーソルの位置
            Line_branch_write() ' 分岐用線引き処理

        End If

    End Sub

    ' ======================================


    ' ====== コントロール移動 ======

    Dim DragTF As Boolean   ' ドラッグ有効/無効 (T: 有効 F: 無効)
    Dim DiffPoint As Point  ' ドラッグ開始地点とドラッグ開始時の位置ズレ

    Dim CtrlNum As Integer  ' コントロールの識別番号
    Dim CtrlX As Integer    ' コントロールのX座標
    Dim CtrlY As Integer    ' コントロールのY座標

    Dim numlist As New ArrayList    ' コントロールの識別番号リスト
    Dim xlist As New ArrayList      ' コントロールのX座標リスト
    Dim ylist As New ArrayList      ' コントロールのY座標リスト

    Dim Ctrl_Gen_num As New Integer ' 生成インデックス(コントロールが何番目に生成されたのか)

    Dim index_xy As Integer = 0 ' コントロールの個数

    ' ドラッグ有効
    Private Sub Ctrl_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' マウス左ボタン押下
        If e.Button = MouseButtons.Left Then

            DragTF = True               　　'ドラッグ有効
            DiffPoint = New Point(e.X, e.Y) '位置ズレを取得

        End If

    End Sub

    ' ドラッグ無効
    Private Sub Ctrl_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' マウス左ボタン離脱
        If e.Button = MouseButtons.Left Then

            DragTF = False              'ドラッグ無効

        End If

    End Sub

    ' ドラッグ
    Private Sub Ctrl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' ドラッグ有効時
        If DragTF Then

            CtrlX = sender.Location.X + e.X - DiffPoint.X    ' X座標の更新
            CtrlY = sender.Location.Y + e.Y - DiffPoint.Y    ' Y座標の更新

            Ctrl_Gen_num = Array.IndexOf(Ctrl_name_list, sender.name) ' 生成インデックス

            ' ドラッグ有効範囲内
            If (CtrlX > -5 And CtrlY > -5) And (CtrlX < 676 And CtrlY < 565) Then

                sender.Location = New Point(CtrlX, CtrlY)   ' 座標の書き換え

                Auto_alignment()    ' 自動整列の範囲定義

                ' 位置情報の保存
                If numlist(Ctrl_Gen_num) = CtrlNum Then

                    numlist(Ctrl_Gen_num) = CtrlNum
                    xlist(Ctrl_Gen_num) = CtrlX
                    ylist(Ctrl_Gen_num) = CtrlY

                ElseIf numlist(index_xy - 1) <> CtrlNum Then

                    numlist.Add(CtrlNum)
                    xlist.Add(CtrlX)
                    ylist.Add(CtrlY)

                    index_xy += 1

                ElseIf Ctrl_Gen_num = 0 Then

                    numlist(Ctrl_Gen_num) = CtrlNum
                    xlist(Ctrl_Gen_num) = CtrlX
                    ylist(Ctrl_Gen_num) = CtrlY

                End If

            End If

            ' 自動整列
            For i = 0 To std - 1 Step 1

                ' 自動整列の範囲内
                If (CtrlX >= borderlandsL(i).X And CtrlX <= borderlandsR(i).X) Or
                (CtrlX + sender.Width >= borderlandsL(i).X And CtrlX + sender.Width <= borderlandsR(i).X) Then

                    ' コントロール
                    If (CtrlX > -5 And CtrlY > -5) And (CtrlX < 676 And CtrlY < 565) Then

                        sender.Location = New Point(borderlandsL(i).X, CtrlY)

                    End If

                    ' テキストツール
                    If (CtrlX > -5 And CtrlY > -5) And (CtrlX < 676 And CtrlY < 565) And sender.Name.IndexOf("pen") > 0 Then

                        sender.Location = New Point(borderlandsL(i).X + 66 - sender.Width / 2, CtrlY)

                    End If

                End If

            Next

        End If

    End Sub

    '=====================================


    ' ===== 自動整列の範囲定義 =====

    Dim align_gen As New ArrayList  ' 基準インデックスリスト
    Dim align_x As New ArrayList    ' 基準のX座標リスト
    Dim align_y As New ArrayList    ' 基準のY座標リスト

    Dim borderlandsL As New ArrayList   ' 自動整列基準(左)
    Dim borderlandsR As New ArrayList   ' 自動整列基準(右)

    Dim std As Integer = 0  ' 基準の個数

    Private Sub Auto_alignment()

        ' ドラッグ無効時かつテキストツール以外
        If DragTF = False And numlist(count - 1) <> 9 Then

            ' 基準の位置情報の保存
            align_gen.Add(count - 1)
            align_x.Add(xlist(count - 1))
            align_y.Add(ylist(count - 1))

            ' 基準の定義
            borderlandsL.Add(New Point(align_x(std), workspace.Height))
            borderlandsR.Add(New Point(align_x(std) + 132, workspace.Height))

            std += 1    ' 基準の個数

        Else    ' ドラッグ有効時

            ' 基準の更新
            For i = 0 To std - 1 Step 1

                ' ドラッグ中のコントロールが基準のものか
                If align_gen(i) = Ctrl_Gen_num Then

                    ' 基準の位置情報の保存
                    align_x(i) = CtrlX
                    align_y(i) = CtrlY

                    ' 基準の定義
                    borderlandsL(i) = New Point(align_x(i), workspace.Height)
                    borderlandsR(i) = New Point(align_x(i) + 132, workspace.Height)

                    Exit For

                End If

            Next

        End If
    End Sub

    ' ====================


    ' ===== 半自動線引き =====

    Dim ft() As Integer = {vbNull, vbNull}    ' 1点目の座標(X, Y)
    Dim sd() As Integer = {vbNull, vbNull}    ' 2点目の座標(X, Y)
    Dim bh() As Integer = {vbNull, vbNull}    ' 分岐の座標(X, Y)

    Dim xylinelist As New ArrayList

    Dim bhdiff As Integer   ' 分岐"のY座標ととクリックされたY座標の距離
    Dim mxy As Point        ' クリックされた座標

    Dim Draw_TF As Boolean = False      ' 線引きの可否 (T: 処理中 F: 待機中)
    Dim Branch_TF As Boolean = False    ' 分岐用線引き処理中か否か (T: 処理中(コントロール生成不可) F: 待機中)

    Dim canvas As Bitmap        ' workspaceのImageオブジェクト
    Dim draw_target As Graphics ' 描画対象(workspaceのImageオブジェクトのGraphicsオブジェクト)
    Dim p As New Pen(Color.Black, 2) ' penオブジェクト

    Dim CtrlName As String = ""     ' コントロール名

    Dim n As Integer = 0    ' 線の座標インデックス

    ' 線引き
    Private Sub Line_Write(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' 線引きツール選択時
        If line_rb.Checked Then

            mxy = workspace.PointToClient(Cursor.Position) ' クリックされた座標
            Dim x As Integer = sender.Location.X    ' コントロールのX座標
            Dim y As Integer = sender.Location.Y    ' コントロールのY座標
            Dim h As Integer = sender.Height        ' コントロールの高さ
            Dim w As Integer = sender.Width         ' コントロールの幅

            CtrlName = sender.Name  ' コントロール名格納

            ' コントロールの上底or下底をクリック->線引き処理
            If (mxy.X >= x And mxy.X <= x + w And mxy.Y >= y - 20 And mxy.Y <= y + 20) _
                Or (mxy.X >= x And mxy.X <= x + w And mxy.Y >= y + h - 20 And mxy.Y <= y + h + 20) Then

                ' 待機時->線引き処理開始
                If Draw_TF = False Then

                    ' 1点目
                    ft(0) = x + w / 2   ' X座標
                    ft(1) = y + h       ' Y座標

                    Draw_TF = True      ' 線引き処理開始

                Else

                    ' 2点目
                    sd(0) = x + w / 2   ' X座標
                    sd(1) = y           ' Y座標

                    ' 逆方向からの線引きを禁止
                    If ft(0) > sd(0) Or ft(1) > sd(1) Then

                        ' 1点目と2点目の座標を初期化
                        ft = {vbNull, vbNull}
                        sd = {vbNull, vbNull}

                        Draw_TF = False     ' 線引き処理終了

                        Exit Sub

                    End If

                End If

                ' 1点目と2点目の座標が定義されたら線引き
                If ft(0) <> vbNull And sd(0) <> vbNull Then

                    draw_target = Graphics.FromImage(canvas)    ' 描画対象更新

                    draw_target.DrawLine(p, ft(0), ft(1), sd(0), sd(1)) ' 線引き

                    workspace.Image = canvas    ' 描画

                    draw_target.Dispose()       ' リソース解放

                    ' 線の位置情報保存
                    xylinelist.Add(ft(0))
                    xylinelist.Add(ft(1))
                    xylinelist.Add(sd(0))
                    xylinelist.Add(sd(1))

                    n += 4  ' 線の座標インデックス更新

                    ' 1点目と2点目の座標を初期化
                    ft = {vbNull, vbNull}
                    sd = {vbNull, vbNull}

                    Draw_TF = False     ' 線引き処理終了

                End If

            End If

            ' クリックされたコントロールが"分岐"->分岐用線引き処理開始
            If CtrlName.IndexOf("branch") > 0 Then

                If Branch_TF = True Then

                    Line_branch_write()

                End If

                ' コントロールの右端をクリック->分岐用線引き処理
                If (mxy.Y >= y + (h / 2) - 5 And mxy.Y <= y + (h / 2) + 5 And mxy.X >= x + w - 10 And mxy.X <= x + w + 10) And Branch_TF = False Then

                    ' "分岐"側
                    bh(0) = x + w           ' X座標
                    bh(1) = y + (h / 2)     ' Y座標

                    Branch_TF = True        ' 分岐用線引き処理開始(コントロール生成不可)

                End If

            End If

        End If

    End Sub

    ' 分岐用線引き
    Private Sub Line_branch_write()

        ' 分岐用線引き処理中
        If Branch_TF = True Then

            bhdiff = Math.Abs(mxy.Y) - bh(1)  ' "分岐"のY座標ととクリックされたY座標の距離

            draw_target = Graphics.FromImage(canvas)    ' 描画対象更新

            ' 分岐用線引き
            draw_target.DrawLine(p, bh(0), bh(1), bh(0) + 80, bh(1))
            draw_target.DrawLine(p, bh(0) + 80, bh(1), bh(0) + 80, bh(1) + bhdiff)
            draw_target.DrawLine(p, bh(0) + 80, bh(1) + bhdiff, mxy.X, bh(1) + bhdiff)

            workspace.Image = canvas    ' 描画

            ' 線の位置情報保存
            xylinelist.Add(bh(0))
            xylinelist.Add(bh(1))
            xylinelist.Add(bh(0) + 80)
            xylinelist.Add(bh(1))
            xylinelist.Add(bh(0) + 80)
            xylinelist.Add(bh(1))
            xylinelist.Add(bh(0) + 80)
            xylinelist.Add(bh(1) + bhdiff)
            xylinelist.Add(bh(0) + 80)
            xylinelist.Add(bh(1) + bhdiff)
            xylinelist.Add(mxy.X)
            xylinelist.Add(bh(1) + bhdiff)

            n += 12  ' 線の座標インデックス更新

            ' "分岐"側の座標を初期化
            bh = {vbNull, vbNull}

            draw_target.Dispose()       ' リソース解放

            Branch_TF = False       ' 分岐用線引き処理終了

        End If

    End Sub

    ' Paintイベント
    Private Sub Paint_Event(ByVal sender As Object, ByVal e As PaintEventArgs) Handles workspace.Paint

        ' 線引き処理
        If Draw_TF = True Then

            Normal_draw(e.Graphics)

        End If

        ' 分岐用線引き処理
        If Branch_TF = True Then

            Branch_draw(e.Graphics)

        End If

    End Sub

    ' 線引き再描画
    Private Sub Normal_draw(ByVal g As Graphics)

        g.DrawLine(p, ft(0), ft(1), sd(0), sd(1))

    End Sub

    ' 分岐用線引き再描画
    Private Sub Branch_draw(ByVal g As Graphics)

        g.DrawLine(p, bh(0), bh(1), bh(0) + 80, bh(1))
        g.DrawLine(p, bh(0) + 80, bh(1), bh(0) + 80, bh(1) + bhdiff)
        g.DrawLine(p, bh(0) + 80, bh(1) + bhdiff, mxy.X, bh(1) + bhdiff)

    End Sub

    ' ========================


    ' ===== テキストボックス動作 =====

    Private text_label As Label ' ラベル
    Private text_list As New ArrayList  ' テキストリスト

    ' 編集状態 -> CtrlでLabelに移す
    Private Sub Text_Border_Edit(ByVal sender As Object, ByVal e As KeyEventArgs)

        ' CTRLキーが押されたら
        If e.Control = True Then

            Dim cs As Char() = sender.Text.ToCharArray()    ' 文字列を1文字ごとに配列へ格納
            Dim crlf_cnt As Integer = 1     ' 改行の回数

            ' 文字列中に改行がされているか
            For cnt = 0 To cs.Length - 1 Step 1

                ' 改行コードが見つかれば
                If cs(cnt) = vbLf Then

                    crlf_cnt += 1   ' 改行の回数を更新

                End If
            Next

            ' プロパティ設定
            text_label = New Label With {
                .Location = New Point(sender.Location.X, sender.Location.Y),
                .Size = New Size(sender.Width, sender.Height * crlf_cnt),
                .Font = New Font("MS UI Gothic", fontsize),
                .TextAlign = ContentAlignment.MiddleLeft,
                .BackColor = Color.Transparent
            }

            ' 文字列を移す
            text_label.Text = sender.Text

            ' イベントハンドラに関連付け
            AddHandler text_label.MouseClick, AddressOf Text_Border_NoEdit

            ' workspaceに描写
            workspace.Controls.Add(text_label)
            text_label.BringToFront()

            Dim str_tmp As String = sender.Text

            ' 改行が含まれていたら</n>に置換
            If str_tmp.IndexOf(vbLf) > 0 Then

                str_tmp = str_tmp.Replace(vbCr + vbLf, "</n>")

            End If

            ' テキスト更新
            For i = 0 To text_list.Count - 1 Step 3

                If sender.name = text_list(i) Then

                    text_list(i + 2) = str_tmp

                    If sender.TextAlign = HorizontalAlignment.Center Then

                        text_label.TextAlign = ContentAlignment.MiddleCenter
                        text_label.BackColor = Color.White

                    End If

                    Exit Sub

                End If

            Next

            ' テキスト情報の保存
            text_list.Add(sender.name)
            text_list.Add(0)

            ' フローチャート記号上のテキストボックスであれば中央ぞろえ&背景色白
            If sender.TextAlign = HorizontalAlignment.Center Then

                text_list(text_list.Count - 1) = vbNull
                text_list.Remove(vbNull)
                text_list.Add(1)

                text_label.TextAlign = ContentAlignment.MiddleCenter
                text_label.BackColor = Color.White

            End If

            ' テキスト保存
            text_list.Add(str_tmp)

            e.Handled = True

        End If

    End Sub

    ' 未編集状態 -> ラベル消去
    Private Sub Text_Border_NoEdit(ByVal sender As Object, ByVal e As MouseEventArgs)

        workspace.Controls.Remove(sender)

    End Sub

    ' フローチャート記号上にテキストボックス生成
    Private Sub Text_In_Pic(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' テキストツール選択時
        If pen_rb.Checked Then

            count += 1

            ' プロパティ設定
            pen = New TextBox With {
                .Location = New Point(sender.Location.X, sender.Location.Y),
                .Name = "name_pen" + count,
                .BorderStyle = BorderStyle.FixedSingle,
                .Font = New Font("MS UI Gothic", fontsize),
                .Multiline = True,
                .ImeMode = ImeMode.On,
                .TextAlign = HorizontalAlignment.Center
            }

            Dim pic_mid As New Point(sender.Location.X + sender.Width / 2, sender.Location.Y + sender.Height / 2)   ' フローチャート記号の中心点
            Dim tex_mid As New Point(pen.Width / 2, pen.Height / 2) ' テキストボックスを1/4にした大きさ

            ' 座標書き換え
            pen.Location = New Point(pic_mid.X - tex_mid.X, pic_mid.Y - tex_mid.Y)

            ' イベントハンドラに関連付け
            AddHandler pen.MouseDown, AddressOf Ctrl_MouseDown
            AddHandler pen.MouseMove, AddressOf Ctrl_MouseMove
            AddHandler pen.MouseUp, AddressOf Ctrl_MouseUp
            AddHandler pen.KeyDown, AddressOf Text_Border_Edit
            AddHandler pen.MouseClick, AddressOf Ctrl_Delete

            ' workspaceに描写
            workspace.Controls.Add(pen)
            pen.BringToFront()

            CtrlNum = 9
            Ctrl_name_list(count - 1) = pen.Name

            ReDim Preserve Ctrl_name_list(count)

            ' 位置情報の保存
            numlist.Add(CtrlNum)
            xlist.Add(x_init)
            ylist.Add(y_init)

            index_xy += 1

            savetf = False  ' 変更状態にする

        End If
    End Sub

    ' ================================


    ' ====== 消去ツール ======

    ' コントロール消去
    Private Sub Ctrl_Delete(ByVal sender As Object, ByVal e As MouseEventArgs)

        ' 消去ツール選択時
        If eraser_rb.Checked Then

            ' コントロールクリア(見かけ上)
            workspace.Controls.Remove(sender)


            ' コントロールが何番目に生成されたか取得
            Dim num As Integer = Array.IndexOf(Ctrl_name_list, sender.name)

            ' NULLを格納
            numlist(num) = vbNull
            xlist(num) = vbNull
            ylist(num) = vbNull



            ' 消去されるコントロールがテキストなら
            If sender.name.IndexOf("pen") > 0 Then

                If text_list.Count > 0 Then

                    For i = 0 To text_list.Count - 1 Step 3


                        If text_list(i + 2) = sender.Text Then

                            text_list(i) = vbNull
                            text_list(i + 1) = vbNull
                            text_list(i + 2) = vbNull
                            text_list.Remove(vbNull)
                            text_list.Remove(vbNull)
                            text_list.Remove(vbNull)

                            Exit For

                        End If

                    Next


                End If

            End If

            ' インデックスを-1する
            count -= 1
            index_xy -= 1

            ' Arraylist中のNULLを削除
            numlist.Remove(vbNull)
            xlist.Remove(vbNull)
            ylist.Remove(vbNull)


            ' 自動整列の基準削除
            For i = 0 To std - 1 Step 1

                    ' 消去したコントロールが自動整列の基準であったか
                    If align_gen(i) = num Then

                        ' NULLを格納
                        align_gen(i) = vbNull
                        align_x(i) = vbNull
                        align_y(i) = vbNull
                        borderlandsL(i) = vbNull
                        borderlandsR(i) = vbNull

                        ' 基準の個数を-1する
                        std -= 1

                        Exit For

                    End If

                Next

                ' 各ArrayList中のNULLを削除
                align_gen.Remove(vbNull)
                align_x.Remove(vbNull)
                align_y.Remove(vbNull)
                borderlandsL.Remove(vbNull)
                borderlandsR.Remove(vbNull)

                ' 基準インデックスリスト書き換え
                For i = 1 To std - 1 Step 1

                    align_gen(i) -= 1

                Next

                ' コントロール名リスト書き換え
                For num = num To UBound(Ctrl_name_list) - 1 Step 1

                    Ctrl_name_list(num) = Ctrl_name_list(num + 1)

                Next

                ' コントロール名リストの最後の要素を削除
                ReDim Preserve Ctrl_name_list(UBound(Ctrl_name_list) - 1)

                count = 0
                index_xy = 0

                ' コントロール名の通し番号の書き換え
                For i = 0 To UBound(Ctrl_name_list) - 1

                    ' コントロールがあるか確認
                    Dim cs As Control = Me.Controls(Ctrl_name_list(i))

                    ' コントロールがなかったら
                    If cs IsNot Nothing Then

                        Ctrl_name_list(i) = System.Text.RegularExpressions.Regex.Replace(Ctrl_name_list(i), "[^A-Za-z_]", "")   ' 名前から数字以外を抽出
                        Ctrl_name_list(i) = Ctrl_name_list(i) + count   ' 新しいコントロール名を格納
                        CType(cs, Control).Name = Ctrl_name_list(i)     ' コントロールの名前を変更

                    End If

                    count += 1
                    index_xy += 1

                Next

            End If

    End Sub

    ' 線消去
    Private Sub Line_Delete()

        For i = 0 To n - 1 Step 1

            ' 線上をクリックしたか
            If mxy.X >= xylinelist(i) - 5 And mxy.X <= xylinelist(i + 2) + 5 And mxy.Y >= xylinelist(i + 1) - 5 And mxy.Y <= xylinelist(i + 3) + 5 Then

                Dim g As Graphics = Graphics.FromImage(canvas)  ' 描画対象更新

                ' 消去する範囲定義
                Dim del_range As New Rectangle(xylinelist(i) - 10, xylinelist(i + 1) - 10, xylinelist(i + 2) - xylinelist(i) + 15, xylinelist(i + 3) - xylinelist(i + 1) + 15)

                ' 消去(見かけ上)
                g.SetClip(del_range)
                g.Clear(Color.Transparent)

                ' NULLを格納
                xylinelist(i) = vbNull
                xylinelist(i + 1) = vbNull
                xylinelist(i + 2) = vbNull
                xylinelist(i + 3) = vbNull

                ' xylinelist中のNULLを削除
                xylinelist.Remove(vbNull)

                ' workspaceの画像更新
                workspace.Image = canvas

                ' リソース破棄
                g.Dispose()

                n -= 4 ' 線の座標インデックスを-4する

                Exit For

            End If

        Next

    End Sub

    ' ========================


    ' ====== ファイル新規作成 ======

    Dim fullpath As String      ' 作業ファイルの絶対パス
    Dim filename As String = "" ' 作業ファイル名

    ' ファイル新規作成(呼び出し)
    Private Sub File_New_Make(sender As Object, e As EventArgs) Handles file_make.Click

        ' ファイル未作成時かつ未変更時
        If filename = "" And savetf = True Then

            ' ダイアログインスタンス作成
            Dim sfd As New SaveFileDialog With {
                .FileName = "新しいファイル.fccs",       ' ファイル名デフォルト設定
                .Filter = "FCCSファイル(*.fccs)|*.fccs", ' [ファイルの種類]の選択肢設定
                .Title = "新規作成",                     ' タイトル設定
                .RestoreDirectory = True,                ' ダイアログボックスを閉じる前に現在のフォルダを復元
                .OverwritePrompt = True,                 ' 既存のファイル名を指定したときの警告
                .CheckPathExists = True                  ' 存在しないパスが指定されたときの警告
            }

            ' OKボタン押下->新規ファイル作成
            If sfd.ShowDialog() = DialogResult.OK Then

                filename = sfd.FileName
                fullpath = IO.Path.GetFullPath(filename)   ' 現在の作業ファイルの絶対パスを取得
                MsgBox(fullpath)                           ' 絶対パスをメッセージボックス表

                ' ファイルインスタンス作成
                Dim sw As New IO.StreamWriter(fullpath, False, System.Text.Encoding.GetEncoding("shift_jis"))

                ' 新規ファイル作成
                File_init(sfd, sw)

                ' リソース破棄
                sw.Dispose()

            End If

            ' リソース破棄
            sfd.Dispose()

        ElseIf savetf = False Then  ' 変更時

            MessageBox.Show("変更が加えられたため、新規でファイルを作成できません。" + vbCrLf + "保存ボタンをクリックしてください。",
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else ' ファイル作成済みのとき

            ' エラーメッセージ表示
            MessageBox.Show("ファイルは既に作成されています。" + vbCrLf + "新規でファイルを作成したい場合は、現在の作業ファイルを閉じてください。",
                            "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    ' ファイル新規作成(処理)
    Private Sub File_init(sfd As Object, sw As Object)

        work_file_name.Text = IO.Path.GetFileName(sfd.FileName) ' 現在の作業ファイル名表示

        ' ファイル情報書込み
        sw.Write("************************************" + vbCrLf)
        sw.Write("FlowChart Creation Software - FCCS" + vbCrLf)
        sw.Write("Caution: Do not modify this file. It may cause error." + vbCrLf)
        sw.Write(vbCrLf + "path: " + fullpath + vbCrLf)
        sw.Write("************************************" + vbCrLf)
        sw.Write(vbCrLf + "#Control" + vbCrLf)

        ' ファイルを閉じる
        sw.Close()

    End Sub

    ' ==============================


    ' ====== ファイル保存 ======

    ' ファイル保存(呼び出し)
    Private Sub File_Write_Save(sender As Object, e As EventArgs) Handles file_save.Click

        File_write_save2()

    End Sub

    ' ファイル保存(処理)
    Private Sub File_write_save2()

        ' ファイル未作成時
        If filename = "" Then

            Dim sfd As New SaveFileDialog With {
                .FileName = "新しいファイル.fccs",       ' ファイル名デフォルト設定
                .Filter = "FCCSファイル(*.fccs)|*.fccs", ' [ファイルの種類]の選択肢設定
                .Title = "新規作成",                     ' タイトル設定
                .RestoreDirectory = True,     ' ダイアログボックスを閉じる前に現在のフォルダを復元
                .OverwritePrompt = True,      ' 既存のファイル名を指定したときの警告
                .CheckPathExists = True       ' 存在しないパスが指定されたときの警告
            }

            ' OKボタン押下->新規ファイル作成後、データ書込み
            If sfd.ShowDialog() = DialogResult.OK Then

                filename = sfd.FileName
                fullpath = IO.Path.GetFullPath(filename)   ' 現在の作業ファイルの絶対パスを取得
                MsgBox(fullpath)                                  ' 絶対パスをメッセージボックス表

                ' ファイルインスタンス作成
                Dim sw As New IO.StreamWriter(fullpath, False, System.Text.Encoding.GetEncoding("shift_jis"))

                File_init(sfd, sw)  ' 新規ファイル作成
                File_write()        ' データ書込み

                ' リソース破棄
                sw.Dispose()

                savetf = True   ' 未変更状態にする

            End If

            ' リソース破棄
            sfd.Dispose()

        Else    ' ファイル作成済み時

            fullpath = IO.Path.GetFullPath(filename) ' 現在の作業ファイルの絶対パスを取得
            MsgBox(fullpath)                                ' 絶対パスをメッセージボックス表
            File_write()    ' データ書込み

            savetf = True   ' 未変更状態にする

        End If

    End Sub

    ' データ書込み
    Private Sub File_write()

        ' データ書込み用ファイルインスタンス作成
        Dim sw2 As New IO.StreamWriter(fullpath, False, System.Text.Encoding.GetEncoding("shift_jis"))

        ' ファイル情報書込み
        sw2.Write("************************************" + vbCrLf)
        sw2.Write("FlowChart Creation Software - FCCS" + vbCrLf)
        sw2.Write("Caution: Do not modify this file. It may cause error." + vbCrLf)
        sw2.Write(vbCrLf + "path: " + fullpath + vbCrLf)
        sw2.Write("************************************" + vbCrLf)

        sw2.Write(vbCrLf + "#Control" + vbCrLf)

        ' 座標データ書込み
        For i = 0 To index_xy - 1 Step 1

            sw2.Write(numlist(i))
            sw2.Write(",")
            sw2.Write(xlist(i))
            sw2.Write(",")
            sw2.Write(ylist(i))
            sw2.Write(",")

            sw2.Write(vbCrLf)

        Next

        Dim Line_count As Integer = xylinelist.Count    ' 線の個数

        sw2.Write(vbCrLf + "#Line" + vbCrLf)

        ' 線の座標データ書込み
        For i = 0 To Line_count - 1 Step 4

            sw2.Write(xylinelist(i))
            sw2.Write(",")
            sw2.Write(xylinelist(i + 1))
            sw2.Write(",")
            sw2.Write(xylinelist(i + 2))
            sw2.Write(",")
            sw2.Write(xylinelist(i + 3))
            sw2.Write(",")

            sw2.Write(vbCrLf)

        Next

        Dim Align_count As Integer = align_gen.Count    ' 基準の個数

        sw2.Write(vbCrLf + "#Align" + vbCrLf)

        ' 基準の座標データ書込み
        For i = 0 To Align_count - 1 Step 1

            sw2.Write(align_gen(i))
            sw2.Write(",")
            sw2.Write(align_x(i))
            sw2.Write(",")
            sw2.Write(align_y(i))
            sw2.Write(",")

            sw2.Write(vbCrLf)

        Next

        Dim text_count As Integer = text_list.Count    ' テキストの個数

        sw2.Write(vbCrLf + "#text" + vbCrLf)

        ' テキスト書き込み
        For i = 0 To text_count - 1 Step 3

            sw2.Write(text_list(i))
            sw2.Write(",")

            sw2.Write(text_list(i + 1))
            sw2.Write(",")

            sw2.Write(text_list(i + 2))
            sw2.Write(",")

            sw2.Write(vbCrLf)

        Next

        ' リソース破棄
        sw2.Close()
        sw2.Dispose()

    End Sub

    ' ==========================


    ' ======= ファイルを開く =======

    Private Sub File_Open_Prs(sender As Object, e As EventArgs) Handles file_open.Click

        Dim strline As String   ' 1行分のデータ
        Dim strTemp() As String ' 1行分のデータ格納リスト
        Dim j As Integer = 0

        ' 保存後変更が加えられていたら
        If savetf = False Then

            Dim msgresult As DialogResult

            ' 確認メッセージ表示
            msgresult = MessageBox.Show("ファイルを開く前に、現在作業しているファイルを閉じる必要があります。" + vbCrLf + "変更を保存しますか？", "ファイルを閉じる", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

            ' Yesボタン押下->データ書込み後、閉じる
            If msgresult = DialogResult.Yes Then

                File_write_save2()
                File_close_prs2()

            ElseIf msgresult = DialogResult.No Then ' Noボタン押下->閉じる

                File_close_prs2()

            Else    ' Cancelボタン押下

                ' 中止
                Exit Sub

            End If

        ElseIf savetf = True Then   ' 保存後変更が加えられていなかったら

            ' 閉じる
            File_close_prs2()

        End If

        ' インスタンス作成
        Dim ofd As New OpenFileDialog With {
            .FileName = "",                           ' ファイル名デフォルト設定
            .Filter = ".FCCSファイル(*.fccs)|*.fccs", ' [ファイルの種類]の選択肢設定
            .Title = "ファイルを開く",                ' タイトル設定
            .RestoreDirectory = True,     ' ダイアログボックスを閉じる前に現在のフォルダを復元
            .CheckFileExists = True,      ' ダイアログボックスを閉じる前に現在のフォルダを復元
            .CheckPathExists = True       ' 存在しないパスが指定されたときの警告
        }

        ' ファイルダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then

            ' 現在のファイルのパスを取得
            work_file_name.Text = IO.Path.GetFileName(ofd.FileName)
            fullpath = IO.Path.GetFullPath(ofd.FileName)
            filename = fullpath

            ' ファイル読込み
            Dim objFile As New IO.StreamReader(ofd.FileName, System.Text.Encoding.GetEncoding("shift_jis"))

            ' ファイル情報をスキップ
            For i = 0 To 8

                ' 行の読込み
                strline = objFile.ReadLine()

            Next

            ' コントロール座標データ読込
            While strline <> ""

                ' 1行のデータを","ごとに配列へ格納
                strTemp = Split(strline, ",")

                ' データ読込み
                For i = 0 To UBound(strTemp) - 1

                    If i = 0 Then

                        numlist.Add(strTemp(i))

                    ElseIf i = 1 Then

                        xlist.Add(strTemp(i))

                    ElseIf i = 2 Then

                        ylist.Add(strTemp(i))

                    End If

                Next

                '次の行へ
                strline = objFile.ReadLine()
                j += 1

            End While

            ' 線の個数
            Dim Line_count As Integer

            ' 行の読込み
            strline = objFile.ReadLine()
            strline = objFile.ReadLine()

            ' 線座標読込み
            While strline <> ""

                ' 1行のデータを","ごとに配列へ格納
                strTemp = Split(strline, ",")

                ' データ読込み
                For i = 0 To UBound(strTemp) - 1 Step 4

                    xylinelist.Add(strTemp(i))
                    xylinelist.Add(strTemp(i + 1))
                    xylinelist.Add(strTemp(i + 2))
                    xylinelist.Add(strTemp(i + 3))
                    Line_count += 4

                Next

                ' 行の読込み
                strline = objFile.ReadLine()

            End While

            ' 行の読込み
            strline = objFile.ReadLine()
            strline = objFile.ReadLine()

            ' 自動整列の基準座標データ読込
            While strline <> ""

                ' 1行のデータを","ごとに配列へ格納
                strTemp = Split(strline, ",")

                ' データ読込み
                For i = 0 To UBound(strTemp) - 1

                    If i = 0 Then

                        align_gen.Add(strTemp(i))

                    ElseIf i = 1 Then

                        align_x.Add(strTemp(i))

                    ElseIf i = 2 Then

                        align_y.Add(strTemp(i))

                    End If

                Next

                '次の行へ
                strline = objFile.ReadLine()

            End While

            ' 行の読込み
            strline = objFile.ReadLine()
            strline = objFile.ReadLine()

            ' テキスト読込み
            While strline <> ""

                ' 1行のデータを","ごとに配列へ格納
                strTemp = Split(strline, ",")

                ' データ読込み
                For i = 0 To UBound(strTemp) - 1 Step 3

                    text_list.Add(strTemp(i))
                    text_list.Add(strTemp(i + 1))
                    text_list.Add(strTemp(i + 2))

                Next

                '次の行へ
                strline = objFile.ReadLine()

            End While

            ' ファイルを閉じる
            objFile.Close()

            Dim k As Integer = 0

            ' コントロール描写
            For i = 0 To j - 1 Step 1

                count += 1

                Select Case numlist(i)

                    Case 0

                        ' プロパティ設定
                        start_finish = New PictureBox With {
                            .Image = My.Resources.stafin2,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_start_finish" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler start_finish.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler start_finish.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler start_finish.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler start_finish.MouseClick, AddressOf Ctrl_Delete
                        AddHandler start_finish.MouseClick, AddressOf Line_Write
                        AddHandler start_finish.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(start_finish)
                        start_finish.BringToFront()

                        CtrlNum = 0
                        Ctrl_name_list(count - 1) = start_finish.Name　'記号の名前を配列に格納

                    Case 1

                        ' プロパティ設定
                        normal_process = New PictureBox With {
                            .Image = My.Resources.syori1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_normal_process" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler normal_process.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler normal_process.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler normal_process.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler normal_process.MouseClick, AddressOf Ctrl_Delete
                        AddHandler normal_process.MouseClick, AddressOf Line_Write
                        AddHandler normal_process.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(normal_process)
                        normal_process.BringToFront()


                        CtrlNum = 1
                        Ctrl_name_list(count - 1) = normal_process.Name '記号の名前を配列に格納

                    Case 2

                        ' プロパティ設定
                        def_process = New PictureBox With {
                            .Image = My.Resources.tesyori1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_def_process" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler def_process.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler def_process.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler def_process.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler def_process.MouseClick, AddressOf Ctrl_Delete
                        AddHandler def_process.MouseClick, AddressOf Line_Write
                        AddHandler def_process.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(def_process)
                        def_process.BringToFront()

                        CtrlNum = 2
                        Ctrl_name_list(count - 1) = def_process.Name '記号の名前を配列に格納

                    Case 3

                        ' プロパティ設定
                        segmentation = New PictureBox With {
                            .Image = My.Resources.seg1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_segmentation" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler segmentation.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler segmentation.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler segmentation.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler segmentation.MouseClick, AddressOf Ctrl_Delete
                        AddHandler segmentation.MouseClick, AddressOf Line_Write
                        AddHandler segmentation.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(segmentation)
                        segmentation.BringToFront()

                        CtrlNum = 3
                        Ctrl_name_list(count - 1) = segmentation.Name '記号の名前を配列に格納

                    Case 4

                        ' プロパティ設定
                        branch = New PictureBox With {
                            .Image = My.Resources.handan1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_branch" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler branch.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler branch.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler branch.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler branch.MouseClick, AddressOf Ctrl_Delete
                        AddHandler branch.MouseClick, AddressOf Line_Write
                        AddHandler branch.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(branch)
                        branch.BringToFront()

                        CtrlNum = 4
                        Ctrl_name_list(count - 1) = branch.Name '記号の名前を配列に格納

                    Case 5

                        ' プロパティ設定
                        ioput = New PictureBox With {
                            .Image = My.Resources.inout1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_ioput" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler ioput.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler ioput.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler ioput.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler ioput.MouseClick, AddressOf Ctrl_Delete
                        AddHandler ioput.MouseClick, AddressOf Line_Write
                        AddHandler ioput.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(ioput)
                        ioput.BringToFront()

                        CtrlNum = 5
                        Ctrl_name_list(count - 1) = ioput.Name '記号の名前を配列に格納


                    Case 6

                        ' プロパティ設定
                        loop_head = New PictureBox With {
                            .Image = My.Resources.head1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_loop_head" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler loop_head.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler loop_head.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler loop_head.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler loop_head.MouseClick, AddressOf Ctrl_Delete
                        AddHandler loop_head.MouseClick, AddressOf Line_Write
                        AddHandler loop_head.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(loop_head)
                        loop_head.BringToFront()

                        CtrlNum = 6
                        Ctrl_name_list(count - 1) = loop_head.Name '記号の名前を配列に格納

                    Case 7

                        ' プロパティ設定
                        loop_bottom = New PictureBox With {
                            .Image = My.Resources.bottom1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_loop_bottom" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler loop_bottom.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler loop_bottom.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler loop_bottom.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler loop_bottom.MouseClick, AddressOf Ctrl_Delete
                        AddHandler loop_bottom.MouseClick, AddressOf Line_Write
                        AddHandler loop_bottom.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(loop_bottom)
                        loop_bottom.BringToFront()

                        CtrlNum = 7
                        Ctrl_name_list(count - 1) = loop_bottom.Name '記号の名前を配列に格納


                    Case 8

                        ' プロパティ設定
                        connector = New PictureBox With {
                            .Image = My.Resources.ketugou1,
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_connector" + count,
                            .Size = New Size(132, 60),
                            .TabIndex = 1,
                            .TabStop = False,
                            .SizeMode = ImageLayout.Zoom
                        }

                        ' イベントハンドラに関連付け
                        AddHandler connector.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler connector.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler connector.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler connector.MouseClick, AddressOf Ctrl_Delete
                        AddHandler connector.MouseClick, AddressOf Line_Write
                        AddHandler connector.MouseClick, AddressOf Text_In_Pic

                        ' workspaceに描写
                        workspace.Controls.Add(connector)
                        connector.BringToFront()

                        CtrlNum = 8
                        Ctrl_name_list(count - 1) = connector.Name '記号の名前を配列に格納

                    Case 9

                        ' プロパティ設定
                        pen = New TextBox With {
                            .Location = New Point(xlist(i), ylist(i)),
                            .Name = "name_pen" + count,
                            .BorderStyle = BorderStyle.FixedSingle,
                            .Font = New Font("MS UI Gothic", fontsize),
                            .Multiline = True,
                            .ImeMode = ImeMode.On,
                            .TextAlign = HorizontalAlignment.Left
                        }

                        ' テキスト反映
                        If text_list(k + 1) = 1 Then

                            pen.TextAlign = HorizontalAlignment.Center
                            pen.Text = text_list(k + 2)

                        ElseIf text_list(k + 1) = 0 Then

                            pen.Text = text_list(k + 2)

                        End If

                        ' テキスト(改行)反映
                        If text_list(k + 2).IndexOf("</n>") > 0 Then

                            pen.Text = text_list(k + 2).Replace("</n>", vbCr + vbLf)

                        End If

                        k += 3

                        ' イベントハンドラに関連付け
                        AddHandler pen.MouseDown, AddressOf Ctrl_MouseDown
                        AddHandler pen.MouseMove, AddressOf Ctrl_MouseMove
                        AddHandler pen.MouseUp, AddressOf Ctrl_MouseUp
                        AddHandler pen.KeyDown, AddressOf Text_Border_Edit
                        AddHandler pen.MouseClick, AddressOf Ctrl_Delete

                        ' workspaceに描写
                        workspace.Controls.Add(pen)
                        pen.BringToFront()

                        CtrlNum = 9
                        Ctrl_name_list(count - 1) = pen.Name '記号の名前を配列に格納

                End Select

                ReDim Preserve Ctrl_name_list(count)

                index_xy += 1

            Next

            ' 線描写
            For i = 1 To Line_count Step 4

                ft(0) = xylinelist(i - 1)
                ft(1) = xylinelist(i)
                sd(0) = xylinelist(i + 1)
                sd(1) = xylinelist(i + 2)

                draw_target = Graphics.FromImage(canvas)    ' 描画対象更新

                draw_target.DrawLine(p, ft(0), ft(1), sd(0), sd(1)) ' 線引き

                workspace.Image = canvas    ' 描画

                ' リソース破棄
                draw_target.Dispose()

                n += 4　' 線の座標インデックスを+4する

                ' 初期化
                ft = {vbNull, vbNull}
                sd = {vbNull, vbNull}

            Next

            ' 自動整列の基準
            For i = 0 To align_gen.Count - 1 Step 1

                ' 基準の定義
                borderlandsL.Add(New Point(align_x(i), workspace.Height))
                borderlandsR.Add(New Point(align_x(i) + 132, workspace.Height))

                std += 1    ' 基準の個数

            Next

            savetf = False  ' 変更状態にする

        End If

    End Sub

    ' ==============================


    ' ====== ファイルを閉じる ======

    Private Sub File_Close_Prs(sender As Object, e As EventArgs) Handles file_close.Click

        ' 保存後変更が加えられていたら
        If savetf = False Then

            Dim msgresult As DialogResult

            ' 確認メッセージ表示
            msgresult = MessageBox.Show("変更を保存しますか？", "ファイルを閉じる", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

            ' Yesボタン押下->データ書込み後、閉じる
            If msgresult = DialogResult.Yes Then

                File_write_save2()
                File_close_prs2()

            ElseIf msgresult = DialogResult.No Then ' Noボタン押下->閉じる

                File_close_prs2()

            Else    ' Cancelボタン押下

                ' 中止

            End If

        ElseIf savetf = True Then   ' 保存後変更が加えられていなかったら

            ' 閉じる
            File_close_prs2()

        End If

    End Sub

    ' データ初期化
    Private Sub File_close_prs2()

        ' workspace上のコントロールを全クリア(見かけ上)
        workspace.Controls.Clear()

        ' 線を全クリア(見かけ上)
        Dim g As Graphics = Graphics.FromImage(canvas)  ' 描画対象更新
        g.Clear(Color.Transparent)
        workspace.Image = canvas

        ' データ初期化
        text_list.Clear()
        numlist.Clear()
        xlist.Clear()
        ylist.Clear()
        xylinelist.Clear()
        align_gen.Clear()
        align_x.Clear()
        align_y.Clear()
        borderlandsL.Clear()
        borderlandsR.Clear()

        ReDim Ctrl_name_list(0)

        count = 0
        index_xy = 0
        n = 0
        std = 0

        ' 作業ファイル名の初期化
        filename = ""
        work_file_name.Text = "新しいファイル.fccs"

        savetf = True   ' 未変更状態にする

    End Sub

    ' ==============================


    ' ===== クリップボードにコピー =====

    Private Sub Clipboard(sender As Object, e As EventArgs) Handles clipcopy.Click

        Dim rc As Rectangle = RectangleToScreen(GroupBox1.Bounds)
        Dim img As New Bitmap(GroupBox1.Width, GroupBox1.Height)
        Dim graph As Graphics = Graphics.FromImage(img)
        Dim filePath As String = Reflection.Assembly.GetExecutingAssembly().Location + "sc"

        ' workspaceをコピー
        graph.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy)

        ' 画像を保存
        img.Save(filePath)

        ' クリップボードにコピー
        Windows.Forms.Clipboard.SetImage(img)

    End Sub

    ' ==================================


    ' ===== フォントサイズ変更 =====

    Dim fontsize As Integer = 10    ' フォントサイズ

    Private Sub Fontsize_change(sender As Object, e As EventArgs) Handles font_size.TextChanged

        fontsize = Int(font_size.SelectedItem)

    End Sub


    ' ==============================

End Class