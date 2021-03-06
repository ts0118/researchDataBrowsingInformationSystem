﻿using DevExpress.Web;
using System;

namespace researchDataBrowsingInformationSystem
{
    public partial class CheckInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("路径读取失败，请刷新后再试！");
                this.ASPxGridView1.Visible = false;
            }
            if (Session["Checkid"] != null)
            {
                SqlDataSource1.SelectParameters[0].DefaultValue = Session["Checkid"].ToString();
                ASPxGridView1.DataBind();
                Session.Remove("Checkid");
            }
            else
            {
                Response.Write("路径读取失败，请刷新后再试！");
                this.ASPxGridView1.Visible = false;
            }
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            String id = e.ButtonID;
            switch (id)
            {
                case "Delete":
                    this.ASPxGridView1.DeleteRow(e.VisibleIndex);
                    break;

                case "Edit":
                    this.ASPxGridView1.StartEdit(e.VisibleIndex);
                    break;

                case "New":
                    this.ASPxGridView1.AddNewRow();
                    break;
            }
        }
    }
}