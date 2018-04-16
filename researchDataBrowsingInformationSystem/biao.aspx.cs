﻿using System;

namespace researchDataBrowsingInformationSystem
{
    public partial class biao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                if (Session["Role"].ToString() == "2")
                {
                    if (Session["Right"].ToString() == "4")
                    {
                        Response.Redirect("default.aspx");
                    }
                    else
                    {

                        SqlDataSource1.SelectParameters[0].DefaultValue = Session["UserName"].ToString();
                        ASPxGridView1.DataBind();
                    }
                }
                else
                {
                    SqlDataSource1.SelectCommand = "SELECT * FROM biao";
                    ASPxGridView1.DataBind();
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
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