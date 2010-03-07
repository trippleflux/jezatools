﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HtmlAgilityPack;
using jeza.Travian.Framework;
using HtmlDocument=HtmlAgilityPack.HtmlDocument;

namespace jeza.Travian.GameCenter
{
    partial class ProcessCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessCenter));
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOverview = new System.Windows.Forms.TabPage();
            this.panelOverviewLogins = new System.Windows.Forms.Panel();
            this.buttonOwerviewSave = new System.Windows.Forms.Button();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.tabPageRallyPoint = new System.Windows.Forms.TabPage();
            this.panelRallyPointVillage = new System.Windows.Forms.Panel();
            this.buttonUpdateRallyPoint = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelRallyPoint = new System.Windows.Forms.Panel();
            this.dataGridViewRallyPoint = new System.Windows.Forms.DataGridView();
            this.tabPageMap = new System.Windows.Forms.TabPage();
            this.panelMapSelection = new System.Windows.Forms.Panel();
            this.buttonMapPopulate = new System.Windows.Forms.Button();
            this.labelMapVillage = new System.Windows.Forms.Label();
            this.comboBoxMapVillages = new System.Windows.Forms.ComboBox();
            this.labelMapDistance = new System.Windows.Forms.Label();
            this.textBoxMapDistance = new System.Windows.Forms.TextBox();
            this.checkBoxFarmsMiddleRisk = new System.Windows.Forms.CheckBox();
            this.checkBoxFarmsLowRisk = new System.Windows.Forms.CheckBox();
            this.checkBoxFarmsHighRish = new System.Windows.Forms.CheckBox();
            this.checkBoxFarmsNoProfit = new System.Windows.Forms.CheckBox();
            this.buttonMapUpdate = new System.Windows.Forms.Button();
            this.checkBoxExcludedAlliances = new System.Windows.Forms.CheckBox();
            this.checkBoxExcludedPlayers = new System.Windows.Forms.CheckBox();
            this.checkBoxOases = new System.Windows.Forms.CheckBox();
            this.checkBoxWar = new System.Windows.Forms.CheckBox();
            this.checkBoxNap = new System.Windows.Forms.CheckBox();
            this.checkBoxAlly = new System.Windows.Forms.CheckBox();
            this.panelMapList = new System.Windows.Forms.Panel();
            this.dataGridViewMap = new System.Windows.Forms.DataGridView();
            this.tabPageBuildQueue = new System.Windows.Forms.TabPage();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();
            this.tabPageMarketPlace = new System.Windows.Forms.TabPage();
            this.tabPageBrowser = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxBrowserUrl = new System.Windows.Forms.TextBox();
            this.buttonBrowserGo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.panelHead = new System.Windows.Forms.Panel();
            this.buttonRun = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelMain.SuspendLayout();
            this.panelTabs.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageOverview.SuspendLayout();
            this.panelOverviewLogins.SuspendLayout();
            this.tabPageRallyPoint.SuspendLayout();
            this.panelRallyPointVillage.SuspendLayout();
            this.panelRallyPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRallyPoint)).BeginInit();
            this.tabPageMap.SuspendLayout();
            this.panelMapSelection.SuspendLayout();
            this.panelMapList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMap)).BeginInit();
            this.tabPageBrowser.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.panelTabs);
            this.panelMain.Controls.Add(this.panelHead);
            this.panelMain.Controls.Add(this.panelStatus);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1193, 865);
            this.panelMain.TabIndex = 0;
            // 
            // panelTabs
            // 
            this.panelTabs.Controls.Add(this.tabControl);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(0, 28);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(1193, 722);
            this.panelTabs.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOverview);
            this.tabControl.Controls.Add(this.tabPageRallyPoint);
            this.tabControl.Controls.Add(this.tabPageMap);
            this.tabControl.Controls.Add(this.tabPageBuildQueue);
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Controls.Add(this.tabPageStatistics);
            this.tabControl.Controls.Add(this.tabPageMarketPlace);
            this.tabControl.Controls.Add(this.tabPageBrowser);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1193, 722);
            this.tabControl.TabIndex = 0;
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // tabPageOverview
            // 
            this.tabPageOverview.Controls.Add(this.panelOverviewLogins);
            this.tabPageOverview.Location = new System.Drawing.Point(4, 22);
            this.tabPageOverview.Name = "tabPageOverview";
            this.tabPageOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOverview.Size = new System.Drawing.Size(1185, 696);
            this.tabPageOverview.TabIndex = 0;
            this.tabPageOverview.Text = "Overview";
            this.tabPageOverview.UseVisualStyleBackColor = true;
            // 
            // panelOverviewLogins
            // 
            this.panelOverviewLogins.Controls.Add(this.buttonOwerviewSave);
            this.panelOverviewLogins.Controls.Add(this.textBoxServer);
            this.panelOverviewLogins.Controls.Add(this.labelServer);
            this.panelOverviewLogins.Controls.Add(this.textBoxPassword);
            this.panelOverviewLogins.Controls.Add(this.labelPassword);
            this.panelOverviewLogins.Controls.Add(this.textBoxUsername);
            this.panelOverviewLogins.Controls.Add(this.labelUsername);
            this.panelOverviewLogins.Location = new System.Drawing.Point(9, 7);
            this.panelOverviewLogins.Name = "panelOverviewLogins";
            this.panelOverviewLogins.Size = new System.Drawing.Size(264, 124);
            this.panelOverviewLogins.TabIndex = 0;
            // 
            // buttonOwerviewSave
            // 
            this.buttonOwerviewSave.Location = new System.Drawing.Point(86, 85);
            this.buttonOwerviewSave.Name = "buttonOwerviewSave";
            this.buttonOwerviewSave.Size = new System.Drawing.Size(150, 23);
            this.buttonOwerviewSave.TabIndex = 14;
            this.buttonOwerviewSave.Text = "Save";
            this.buttonOwerviewSave.UseVisualStyleBackColor = true;
            this.buttonOwerviewSave.Click += new System.EventHandler(this.buttonOwerviewSave_Click);
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(86, 6);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(150, 20);
            this.textBoxServer.TabIndex = 13;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(3, 13);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 12;
            this.labelServer.Text = "Server";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(86, 58);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(150, 20);
            this.textBoxPassword.TabIndex = 11;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(3, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 10;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(86, 32);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(150, 20);
            this.textBoxUsername.TabIndex = 9;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(1, 39);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 8;
            this.labelUsername.Text = "Username";
            // 
            // tabPageRallyPoint
            // 
            this.tabPageRallyPoint.Controls.Add(this.panelRallyPointVillage);
            this.tabPageRallyPoint.Controls.Add(this.panelRallyPoint);
            this.tabPageRallyPoint.Location = new System.Drawing.Point(4, 22);
            this.tabPageRallyPoint.Name = "tabPageRallyPoint";
            this.tabPageRallyPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRallyPoint.Size = new System.Drawing.Size(1185, 696);
            this.tabPageRallyPoint.TabIndex = 1;
            this.tabPageRallyPoint.Text = "Rally Point";
            this.tabPageRallyPoint.UseVisualStyleBackColor = true;
            // 
            // panelRallyPointVillage
            // 
            this.panelRallyPointVillage.Controls.Add(this.buttonUpdateRallyPoint);
            this.panelRallyPointVillage.Controls.Add(this.comboBox1);
            this.panelRallyPointVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRallyPointVillage.Location = new System.Drawing.Point(3, 3);
            this.panelRallyPointVillage.Name = "panelRallyPointVillage";
            this.panelRallyPointVillage.Size = new System.Drawing.Size(1179, 35);
            this.panelRallyPointVillage.TabIndex = 3;
            // 
            // buttonUpdateRallyPoint
            // 
            this.buttonUpdateRallyPoint.Location = new System.Drawing.Point(207, 3);
            this.buttonUpdateRallyPoint.Name = "buttonUpdateRallyPoint";
            this.buttonUpdateRallyPoint.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateRallyPoint.TabIndex = 1;
            this.buttonUpdateRallyPoint.Text = "Update";
            this.buttonUpdateRallyPoint.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(198, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // panelRallyPoint
            // 
            this.panelRallyPoint.Controls.Add(this.dataGridViewRallyPoint);
            this.panelRallyPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRallyPoint.Location = new System.Drawing.Point(3, 3);
            this.panelRallyPoint.Name = "panelRallyPoint";
            this.panelRallyPoint.Size = new System.Drawing.Size(1179, 690);
            this.panelRallyPoint.TabIndex = 2;
            // 
            // dataGridViewRallyPoint
            // 
            this.dataGridViewRallyPoint.AllowUserToAddRows = false;
            this.dataGridViewRallyPoint.AllowUserToDeleteRows = false;
            this.dataGridViewRallyPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRallyPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRallyPoint.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRallyPoint.Name = "dataGridViewRallyPoint";
            this.dataGridViewRallyPoint.ReadOnly = true;
            this.dataGridViewRallyPoint.Size = new System.Drawing.Size(1179, 690);
            this.dataGridViewRallyPoint.TabIndex = 0;
            // 
            // tabPageMap
            // 
            this.tabPageMap.Controls.Add(this.panelMapSelection);
            this.tabPageMap.Controls.Add(this.panelMapList);
            this.tabPageMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageMap.Name = "tabPageMap";
            this.tabPageMap.Size = new System.Drawing.Size(1185, 696);
            this.tabPageMap.TabIndex = 2;
            this.tabPageMap.Text = "Map";
            this.tabPageMap.UseVisualStyleBackColor = true;
            // 
            // panelMapSelection
            // 
            this.panelMapSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMapSelection.Controls.Add(this.buttonMapPopulate);
            this.panelMapSelection.Controls.Add(this.labelMapVillage);
            this.panelMapSelection.Controls.Add(this.comboBoxMapVillages);
            this.panelMapSelection.Controls.Add(this.labelMapDistance);
            this.panelMapSelection.Controls.Add(this.textBoxMapDistance);
            this.panelMapSelection.Controls.Add(this.checkBoxFarmsMiddleRisk);
            this.panelMapSelection.Controls.Add(this.checkBoxFarmsLowRisk);
            this.panelMapSelection.Controls.Add(this.checkBoxFarmsHighRish);
            this.panelMapSelection.Controls.Add(this.checkBoxFarmsNoProfit);
            this.panelMapSelection.Controls.Add(this.buttonMapUpdate);
            this.panelMapSelection.Controls.Add(this.checkBoxExcludedAlliances);
            this.panelMapSelection.Controls.Add(this.checkBoxExcludedPlayers);
            this.panelMapSelection.Controls.Add(this.checkBoxOases);
            this.panelMapSelection.Controls.Add(this.checkBoxWar);
            this.panelMapSelection.Controls.Add(this.checkBoxNap);
            this.panelMapSelection.Controls.Add(this.checkBoxAlly);
            this.panelMapSelection.Location = new System.Drawing.Point(0, 0);
            this.panelMapSelection.Name = "panelMapSelection";
            this.panelMapSelection.Size = new System.Drawing.Size(173, 696);
            this.panelMapSelection.TabIndex = 1;
            // 
            // buttonMapPopulate
            // 
            this.buttonMapPopulate.Location = new System.Drawing.Point(4, 235);
            this.buttonMapPopulate.Name = "buttonMapPopulate";
            this.buttonMapPopulate.Size = new System.Drawing.Size(75, 23);
            this.buttonMapPopulate.TabIndex = 17;
            this.buttonMapPopulate.Text = "Populate";
            this.buttonMapPopulate.UseVisualStyleBackColor = true;
            // 
            // labelMapVillage
            // 
            this.labelMapVillage.AutoSize = true;
            this.labelMapVillage.Location = new System.Drawing.Point(8, 320);
            this.labelMapVillage.Name = "labelMapVillage";
            this.labelMapVillage.Size = new System.Drawing.Size(38, 13);
            this.labelMapVillage.TabIndex = 16;
            this.labelMapVillage.Text = "Village";
            // 
            // comboBoxMapVillages
            // 
            this.comboBoxMapVillages.FormattingEnabled = true;
            this.comboBoxMapVillages.Location = new System.Drawing.Point(8, 336);
            this.comboBoxMapVillages.Name = "comboBoxMapVillages";
            this.comboBoxMapVillages.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMapVillages.TabIndex = 15;
            // 
            // labelMapDistance
            // 
            this.labelMapDistance.AutoSize = true;
            this.labelMapDistance.Location = new System.Drawing.Point(8, 281);
            this.labelMapDistance.Name = "labelMapDistance";
            this.labelMapDistance.Size = new System.Drawing.Size(49, 13);
            this.labelMapDistance.TabIndex = 14;
            this.labelMapDistance.Text = "Distance";
            // 
            // textBoxMapDistance
            // 
            this.textBoxMapDistance.Location = new System.Drawing.Point(8, 297);
            this.textBoxMapDistance.Name = "textBoxMapDistance";
            this.textBoxMapDistance.Size = new System.Drawing.Size(119, 20);
            this.textBoxMapDistance.TabIndex = 13;
            this.textBoxMapDistance.Text = "1";
            // 
            // checkBoxFarmsMiddleRisk
            // 
            this.checkBoxFarmsMiddleRisk.AutoSize = true;
            this.checkBoxFarmsMiddleRisk.Checked = true;
            this.checkBoxFarmsMiddleRisk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFarmsMiddleRisk.Location = new System.Drawing.Point(4, 188);
            this.checkBoxFarmsMiddleRisk.Name = "checkBoxFarmsMiddleRisk";
            this.checkBoxFarmsMiddleRisk.Size = new System.Drawing.Size(142, 17);
            this.checkBoxFarmsMiddleRisk.TabIndex = 12;
            this.checkBoxFarmsMiddleRisk.Text = "Show Middle Risk Farms";
            this.checkBoxFarmsMiddleRisk.UseVisualStyleBackColor = true;
            // 
            // checkBoxFarmsLowRisk
            // 
            this.checkBoxFarmsLowRisk.AutoSize = true;
            this.checkBoxFarmsLowRisk.Checked = true;
            this.checkBoxFarmsLowRisk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFarmsLowRisk.Location = new System.Drawing.Point(4, 165);
            this.checkBoxFarmsLowRisk.Name = "checkBoxFarmsLowRisk";
            this.checkBoxFarmsLowRisk.Size = new System.Drawing.Size(134, 17);
            this.checkBoxFarmsLowRisk.TabIndex = 11;
            this.checkBoxFarmsLowRisk.Text = "Show Low Risk  Farms";
            this.checkBoxFarmsLowRisk.UseVisualStyleBackColor = true;
            // 
            // checkBoxFarmsHighRish
            // 
            this.checkBoxFarmsHighRish.AutoSize = true;
            this.checkBoxFarmsHighRish.Location = new System.Drawing.Point(4, 211);
            this.checkBoxFarmsHighRish.Name = "checkBoxFarmsHighRish";
            this.checkBoxFarmsHighRish.Size = new System.Drawing.Size(133, 17);
            this.checkBoxFarmsHighRish.TabIndex = 10;
            this.checkBoxFarmsHighRish.Text = "Show High Risk Farms";
            this.checkBoxFarmsHighRish.UseVisualStyleBackColor = true;
            // 
            // checkBoxFarmsNoProfit
            // 
            this.checkBoxFarmsNoProfit.AutoSize = true;
            this.checkBoxFarmsNoProfit.Location = new System.Drawing.Point(4, 142);
            this.checkBoxFarmsNoProfit.Name = "checkBoxFarmsNoProfit";
            this.checkBoxFarmsNoProfit.Size = new System.Drawing.Size(123, 17);
            this.checkBoxFarmsNoProfit.TabIndex = 7;
            this.checkBoxFarmsNoProfit.Text = "Show No Profit Farm";
            this.checkBoxFarmsNoProfit.UseVisualStyleBackColor = true;
            // 
            // buttonMapUpdate
            // 
            this.buttonMapUpdate.Location = new System.Drawing.Point(8, 363);
            this.buttonMapUpdate.Name = "buttonMapUpdate";
            this.buttonMapUpdate.Size = new System.Drawing.Size(123, 23);
            this.buttonMapUpdate.TabIndex = 6;
            this.buttonMapUpdate.Text = "Update";
            this.buttonMapUpdate.UseVisualStyleBackColor = true;
            this.buttonMapUpdate.Click += new System.EventHandler(this.buttonMapUpdate_Click);
            // 
            // checkBoxExcludedAlliances
            // 
            this.checkBoxExcludedAlliances.AutoSize = true;
            this.checkBoxExcludedAlliances.Location = new System.Drawing.Point(3, 119);
            this.checkBoxExcludedAlliances.Name = "checkBoxExcludedAlliances";
            this.checkBoxExcludedAlliances.Size = new System.Drawing.Size(145, 17);
            this.checkBoxExcludedAlliances.TabIndex = 5;
            this.checkBoxExcludedAlliances.Text = "Show Excluded Alliances";
            this.checkBoxExcludedAlliances.UseVisualStyleBackColor = true;
            // 
            // checkBoxExcludedPlayers
            // 
            this.checkBoxExcludedPlayers.AutoSize = true;
            this.checkBoxExcludedPlayers.Location = new System.Drawing.Point(4, 96);
            this.checkBoxExcludedPlayers.Name = "checkBoxExcludedPlayers";
            this.checkBoxExcludedPlayers.Size = new System.Drawing.Size(137, 17);
            this.checkBoxExcludedPlayers.TabIndex = 4;
            this.checkBoxExcludedPlayers.Text = "Show Excluded Players";
            this.checkBoxExcludedPlayers.UseVisualStyleBackColor = true;
            // 
            // checkBoxOases
            // 
            this.checkBoxOases.AutoSize = true;
            this.checkBoxOases.Location = new System.Drawing.Point(4, 73);
            this.checkBoxOases.Name = "checkBoxOases";
            this.checkBoxOases.Size = new System.Drawing.Size(86, 17);
            this.checkBoxOases.TabIndex = 3;
            this.checkBoxOases.Text = "Show Oases";
            this.checkBoxOases.UseVisualStyleBackColor = true;
            // 
            // checkBoxWar
            // 
            this.checkBoxWar.AutoSize = true;
            this.checkBoxWar.Location = new System.Drawing.Point(4, 50);
            this.checkBoxWar.Name = "checkBoxWar";
            this.checkBoxWar.Size = new System.Drawing.Size(116, 17);
            this.checkBoxWar.TabIndex = 2;
            this.checkBoxWar.Text = "Show Alliance War";
            this.checkBoxWar.UseVisualStyleBackColor = true;
            // 
            // checkBoxNap
            // 
            this.checkBoxNap.AutoSize = true;
            this.checkBoxNap.Location = new System.Drawing.Point(3, 27);
            this.checkBoxNap.Name = "checkBoxNap";
            this.checkBoxNap.Size = new System.Drawing.Size(116, 17);
            this.checkBoxNap.TabIndex = 1;
            this.checkBoxNap.Text = "Show Alliance Nap";
            this.checkBoxNap.UseVisualStyleBackColor = true;
            // 
            // checkBoxAlly
            // 
            this.checkBoxAlly.AutoSize = true;
            this.checkBoxAlly.Location = new System.Drawing.Point(4, 4);
            this.checkBoxAlly.Name = "checkBoxAlly";
            this.checkBoxAlly.Size = new System.Drawing.Size(112, 17);
            this.checkBoxAlly.TabIndex = 0;
            this.checkBoxAlly.Text = "Show Alliance Ally";
            this.checkBoxAlly.UseVisualStyleBackColor = true;
            // 
            // panelMapList
            // 
            this.panelMapList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMapList.Controls.Add(this.dataGridViewMap);
            this.panelMapList.Location = new System.Drawing.Point(179, 4);
            this.panelMapList.Name = "panelMapList";
            this.panelMapList.Size = new System.Drawing.Size(1006, 692);
            this.panelMapList.TabIndex = 0;
            // 
            // dataGridViewMap
            // 
            this.dataGridViewMap.AllowUserToAddRows = false;
            this.dataGridViewMap.AllowUserToDeleteRows = false;
            this.dataGridViewMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMap.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMap.Name = "dataGridViewMap";
            this.dataGridViewMap.ReadOnly = true;
            this.dataGridViewMap.Size = new System.Drawing.Size(1006, 692);
            this.dataGridViewMap.TabIndex = 0;
            // 
            // tabPageBuildQueue
            // 
            this.tabPageBuildQueue.Location = new System.Drawing.Point(4, 22);
            this.tabPageBuildQueue.Name = "tabPageBuildQueue";
            this.tabPageBuildQueue.Size = new System.Drawing.Size(1185, 696);
            this.tabPageBuildQueue.TabIndex = 3;
            this.tabPageBuildQueue.Text = "Build Queue";
            this.tabPageBuildQueue.UseVisualStyleBackColor = true;
            // 
            // tabPageReports
            // 
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Size = new System.Drawing.Size(1185, 696);
            this.tabPageReports.TabIndex = 4;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // tabPageStatistics
            // 
            this.tabPageStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatistics.Name = "tabPageStatistics";
            this.tabPageStatistics.Size = new System.Drawing.Size(1185, 696);
            this.tabPageStatistics.TabIndex = 5;
            this.tabPageStatistics.Text = "Statistics";
            this.tabPageStatistics.UseVisualStyleBackColor = true;
            // 
            // tabPageMarketPlace
            // 
            this.tabPageMarketPlace.Location = new System.Drawing.Point(4, 22);
            this.tabPageMarketPlace.Name = "tabPageMarketPlace";
            this.tabPageMarketPlace.Size = new System.Drawing.Size(1185, 696);
            this.tabPageMarketPlace.TabIndex = 6;
            this.tabPageMarketPlace.Text = "MarketPlace";
            this.tabPageMarketPlace.UseVisualStyleBackColor = true;
            // 
            // tabPageBrowser
            // 
            this.tabPageBrowser.Controls.Add(this.panel2);
            this.tabPageBrowser.Controls.Add(this.panel1);
            this.tabPageBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabPageBrowser.Name = "tabPageBrowser";
            this.tabPageBrowser.Size = new System.Drawing.Size(1185, 696);
            this.tabPageBrowser.TabIndex = 7;
            this.tabPageBrowser.Text = "Browser";
            this.tabPageBrowser.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxBrowserUrl);
            this.panel2.Controls.Add(this.buttonBrowserGo);
            this.panel2.Location = new System.Drawing.Point(9, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 39);
            this.panel2.TabIndex = 1;
            // 
            // textBoxBrowserUrl
            // 
            this.textBoxBrowserUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBrowserUrl.Location = new System.Drawing.Point(-1, 5);
            this.textBoxBrowserUrl.Name = "textBoxBrowserUrl";
            this.textBoxBrowserUrl.Size = new System.Drawing.Size(919, 20);
            this.textBoxBrowserUrl.TabIndex = 4;
            // 
            // buttonBrowserGo
            // 
            this.buttonBrowserGo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonBrowserGo.Location = new System.Drawing.Point(924, 3);
            this.buttonBrowserGo.Name = "buttonBrowserGo";
            this.buttonBrowserGo.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowserGo.TabIndex = 3;
            this.buttonBrowserGo.Text = "Go";
            this.buttonBrowserGo.UseVisualStyleBackColor = true;
            this.buttonBrowserGo.Click += new System.EventHandler(this.buttonBrowserGo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1185, 696);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(7, 49);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1167, 644);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // panelHead
            // 
            this.panelHead.AutoSize = true;
            this.panelHead.Controls.Add(this.buttonRun);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(1193, 28);
            this.panelHead.TabIndex = 2;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(12, 2);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Start";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.SetBotStatus);
            // 
            // panelStatus
            // 
            this.panelStatus.AutoSize = true;
            this.panelStatus.Controls.Add(this.textBoxStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 750);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1193, 115);
            this.panelStatus.TabIndex = 0;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(4, 4);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxStatus.Size = new System.Drawing.Size(1185, 108);
            this.textBoxStatus.TabIndex = 0;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Game Center";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // mapBindingSource
            // 
            this.mapBindingSource.DataSource = typeof(jeza.Travian.Framework.Map);
            // 
            // ProcessCenter
            // 
            this.ClientSize = new System.Drawing.Size(1193, 865);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessCenter";
            this.Load += new System.EventHandler(this.ProcessCenter_Load);
            this.Resize += new System.EventHandler(this.ProcessCenter_Resize);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelTabs.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageOverview.ResumeLayout(false);
            this.panelOverviewLogins.ResumeLayout(false);
            this.panelOverviewLogins.PerformLayout();
            this.tabPageRallyPoint.ResumeLayout(false);
            this.panelRallyPointVillage.ResumeLayout(false);
            this.panelRallyPoint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRallyPoint)).EndInit();
            this.tabPageMap.ResumeLayout(false);
            this.panelMapSelection.ResumeLayout(false);
            this.panelMapSelection.PerformLayout();
            this.panelMapList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMap)).EndInit();
            this.tabPageBrowser.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelHead.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelMain;
        private Panel panelTabs;
        private TabControl tabControl;
        private TabPage tabPageOverview;
        private TabPage tabPageRallyPoint;
        private Panel panelStatus;
        private Panel panelHead;
        private Button buttonRun;
        private TextBox textBoxStatus;
        private Panel panelRallyPointVillage;
        private Button buttonUpdateRallyPoint;
        private ComboBox comboBox1;
        private Panel panelRallyPoint;
        private DataGridView dataGridViewRallyPoint;
        private TabPage tabPageMap;
        private Panel panelMapSelection;
        private CheckBox checkBoxExcludedAlliances;
        private CheckBox checkBoxExcludedPlayers;
        private CheckBox checkBoxOases;
        private CheckBox checkBoxWar;
        private CheckBox checkBoxNap;
        private CheckBox checkBoxAlly;
        private Panel panelMapList;
        private Button buttonMapUpdate;
        private DataGridView dataGridViewMap;
        private CheckBox checkBoxFarmsNoProfit;
        private TabPage tabPageBuildQueue;
        private TabPage tabPageReports;
        private TabPage tabPageStatistics;
        private TabPage tabPageMarketPlace;
        private TabPage tabPageBrowser;
        private Panel panel1;
        private WebBrowser webBrowser;
        private Panel panel2;
        private TextBox textBoxBrowserUrl;
        private Button buttonBrowserGo;
        private NotifyIcon notifyIcon;
        
        readonly object stateLock = new object();
        private bool botActive;
        private readonly HtmlWeb htmlWeb = new HtmlWeb();
        private HtmlDocument htmlDocument;
        private Settings settings;
        private Account account;
        private Map map;

        delegate void StringParameterDelegate(string value);
        delegate void SetDataGridViewDataBind(DataGridView field, ArrayList list);
        delegate void SetButtonStatus(Button button, bool enabled);

        private CheckBox checkBoxFarmsMiddleRisk;
        private CheckBox checkBoxFarmsLowRisk;
        private CheckBox checkBoxFarmsHighRish;
        private Label labelMapVillage;
        private ComboBox comboBoxMapVillages;
        private Label labelMapDistance;
        private TextBox textBoxMapDistance;
        private Button buttonMapPopulate;
        private Panel panelOverviewLogins;
        private TextBox textBoxServer;
        private Label labelServer;
        private TextBox textBoxPassword;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private Label labelUsername;
        private Button buttonOwerviewSave;
        private BindingSource mapBindingSource;
    }
}

