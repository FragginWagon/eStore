using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eStoreWebObjects;
using System.Collections;

public partial class ProductUpdater : System.Web.UI.Page
{
    DataTable _table = new DataTable();
    string _sortExpr = "prodcd";
    bool _needFreshData = true;

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            _needFreshData = true;
            BindData(_sortExpr);
        }
        else
        {
            _table = (DataTable)Session["table"];
            _sortExpr = (string)Session["sort"];
            _needFreshData = false;
        }
    }
    /// <summary>
    /// Handles the RowEditing event of the grdVwProducts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void grdVwProducts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdVwProducts.EditIndex = e.NewEditIndex;
        Session["prodcd"] = grdVwProducts.Rows[e.NewEditIndex].Cells[0].Text;
        BindData(_sortExpr);
    }
    /// <summary>
    /// Handles the Sorting event of the grdVwProducts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewSortEventArgs"/> instance containing the event data.</param>
    protected void grdVwProducts_Sorting(object sender, GridViewSortEventArgs e)
    {
        Session["sort"] = e.SortExpression;
        BindData(e.SortExpression);
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the grdVwProducts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void grdVwProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Server.Transfer("ProductUpdater.aspx");
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the grdVwProducts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void grdVwProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdVwProducts.PageIndex = e.NewPageIndex;
        BindData(_sortExpr);
    }
    /// <summary>
    /// Handles the RowUpdating event of the grdVwProducts control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void grdVwProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            Hashtable hshProd = new Hashtable();
            Product myProd = new Product();

            // Grab the data out of the gridview
            hshProd["prodcd"] = Convert.ToString(Session["prodcd"]);
            hshProd["prodnam"] = ((TextBox)grdVwProducts.Rows[grdVwProducts.EditIndex].Cells[1].Controls[0]).Text;
            hshProd["graphic"] = ((TextBox)grdVwProducts.Rows[grdVwProducts.EditIndex].Cells[2].Controls[0]).Text;
            hshProd["cost"] = Convert.ToDouble(((TextBox)grdVwProducts.Rows[grdVwProducts.EditIndex].Cells[3].Controls[0]).Text);
            hshProd["msrp"] = Convert.ToDouble(((TextBox)grdVwProducts.Rows[grdVwProducts.EditIndex].Cells[4].Controls[0]).Text);
            hshProd["qoh"] = Convert.ToInt32(((TextBox)grdVwProducts.Rows[grdVwProducts.EditIndex].Cells[5].Controls[0]).Text);
            hshProd["qob"] = Convert.ToInt32(((TextBox)grdVwProducts.Rows[grdVwProducts.EditIndex].Cells[6].Controls[0]).Text);

            // now do the update
            bool updateOk = myProd.UpdateProduct(hshProd);

            grdVwProducts.EditIndex = -1;
            _needFreshData = true;  // for page_load back to the database to get new changes
            BindData(_sortExpr);
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }

    /// <summary>
    /// If the first time on a page or an update has occured return to
    /// the db for fresh data, else use session object to hold data
    /// <summary>
    /// <param name="sortExpr"></param>
    protected void BindData(string sortExpr)
    {
        try
        {
            Product myProd = new Product();
            if (_needFreshData)
            {
                _table = myProd.GetProducts();
                Session["table"] = _table;
                Session["sort"] = _sortExpr;
                _needFreshData = false;
            }

            DataView dv = new DataView(_table);
            dv.Sort = sortExpr;
            grdVwProducts.DataSource = dv;
            grdVwProducts.DataBind();
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
    }
    protected void grdVwProducts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
