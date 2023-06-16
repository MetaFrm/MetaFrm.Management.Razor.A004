using MetaFrm.Database;
using MetaFrm.Extensions;
using MetaFrm.Management.Razor.Models;
using MetaFrm.Management.Razor.ViewModels;
using MetaFrm.Razor.Essentials;
using MetaFrm.Service;
using MetaFrm.Web.Bootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MetaFrm.Management.Razor
{
    /// <summary>
    /// A004
    /// </summary>
    public partial class A004
    {
        #region Variable
        internal A004ViewModel A004ViewModel { get; set; } = Factory.CreateViewModel<A004ViewModel>();

        internal DataGridControl<CommonClassModel>? DataGridControl;

        internal IEnumerable<Data.DataRow>? CommonClassItems;

        internal CommonClassModel SelectItem = new();

        internal int? PagingSize = null;
        #endregion


        #region Init
        /// <summary>
        /// OnInitializedAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task<Task> OnInitializedAsync()
        {
            try
            {
                if (this.JSRuntime != null)
                {
                    System.Drawing.Size browserDimension = await this.JSRuntime.InvokeAsync<System.Drawing.Size>("getDimensions", null);
                    int? tmp = (browserDimension.Height - 210) / this.DataGridControl.HeaderHeight;
                    this.PagingSize = tmp < 5 ? 5 : tmp;
                }
            }
            catch (Exception) { }

            return base.OnInitializedAsync();
        }

        /// <summary>
        /// OnAfterRenderAsync
        /// </summary>
        /// <param name="firstRender"></param>
        /// <returns></returns>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (!this.IsLogin())
                    this.Navigation?.NavigateTo("/", true);

                this.A004ViewModel = await this.GetSession<A004ViewModel>(nameof(this.A004ViewModel));

                this.Search();

                this.StateHasChanged();
            }
        }
        #endregion


        #region Dictionary
        private void OnResultEventCommonClassItems(IEnumerable<Data.DataRow> dataRows) => this.CommonClassItems = dataRows;
        #endregion


        #region IO
        private void New()
        {
            this.SelectItem = new();
        }

        private void OnSearch()
        {
            if (this.DataGridControl != null)
                this.DataGridControl.CurrentPageNumber = 1;

            this.Search();
        }
        private void Search()
        {
            Response response;

            try
            {
                if (this.A004ViewModel.IsBusy) return;

                this.A004ViewModel.IsBusy = true;

                ServiceData serviceData = new()
                {
                    Token = this.UserClaim("Token")
                };
                serviceData["1"].CommandText = this.GetAttribute("Search");
                serviceData["1"].AddParameter(nameof(this.A004ViewModel.SearchModel.SEARCH_TEXT), DbType.NVarChar, 4000, this.A004ViewModel.SearchModel.SEARCH_TEXT);
                serviceData["1"].AddParameter("USER_ID", DbType.Int, 3, this.UserClaim("Account.USER_ID").ToInt());
                serviceData["1"].AddParameter("PAGE_NO", DbType.Int, 3, this.DataGridControl != null ? this.DataGridControl.CurrentPageNumber : 1);
                serviceData["1"].AddParameter("PAGE_SIZE", DbType.Int, 3, this.DataGridControl != null && this.DataGridControl.PagingEnabled ? this.DataGridControl.PagingSize : int.MaxValue);

                response = serviceData.ServiceRequest(serviceData);

                if (response.Status == Status.OK)
                {
                    this.A004ViewModel.SelectResultModel.Clear();

                    if (response.DataSet != null && response.DataSet.DataTables.Count > 0)
                    {
                        var orderResult = response.DataSet.DataTables[0].DataRows.OrderBy(x => x.String(nameof(CommonClassModel.CLASS_NAME)));

                        foreach (var datarow in orderResult)
                        {
                            this.A004ViewModel.SelectResultModel.Add(new CommonClassModel
                            {
                                CLASS_VALUE_ID = datarow.Int(nameof(CommonClassModel.CLASS_VALUE_ID)),
                                CLASS_ID = datarow.Int(nameof(CommonClassModel.CLASS_ID)),
                                CLASS_NAME = datarow.String(nameof(CommonClassModel.CLASS_NAME)),
                                INACTIVE_DATE = datarow.DateTime(nameof(CommonClassModel.INACTIVE_DATE)),
                                KEY_VALUE = datarow.String(nameof(CommonClassModel.KEY_VALUE)),
                                TEXT_VALUE1 = datarow.String(nameof(CommonClassModel.TEXT_VALUE1)),
                                TEXT_VALUE2 = datarow.String(nameof(CommonClassModel.TEXT_VALUE2)),
                                TEXT_VALUE3 = datarow.String(nameof(CommonClassModel.TEXT_VALUE3)),
                                TEXT_VALUE4 = datarow.String(nameof(CommonClassModel.TEXT_VALUE4)),
                                TEXT_VALUE5 = datarow.String(nameof(CommonClassModel.TEXT_VALUE5)),
                                TEXT_VALUE6 = datarow.String(nameof(CommonClassModel.TEXT_VALUE6)),
                                TEXT_VALUE7 = datarow.String(nameof(CommonClassModel.TEXT_VALUE7)),
                                TEXT_VALUE8 = datarow.String(nameof(CommonClassModel.TEXT_VALUE8)),
                                TEXT_VALUE9 = datarow.String(nameof(CommonClassModel.TEXT_VALUE9)),
                                TEXT_VALUE10 = datarow.String(nameof(CommonClassModel.TEXT_VALUE10)),
                                INT_VALUE1 = datarow.Int(nameof(CommonClassModel.INT_VALUE1)),
                                INT_VALUE2 = datarow.Int(nameof(CommonClassModel.INT_VALUE2)),
                                INT_VALUE3 = datarow.Int(nameof(CommonClassModel.INT_VALUE3)),
                                INT_VALUE4 = datarow.Int(nameof(CommonClassModel.INT_VALUE4)),
                                INT_VALUE5 = datarow.Int(nameof(CommonClassModel.INT_VALUE5)),
                                NUMBER_VALUE1 = datarow.Decimal(nameof(CommonClassModel.NUMBER_VALUE1)),
                                NUMBER_VALUE2 = datarow.Decimal(nameof(CommonClassModel.NUMBER_VALUE2)),
                                NUMBER_VALUE3 = datarow.Decimal(nameof(CommonClassModel.NUMBER_VALUE3)),
                                NUMBER_VALUE4 = datarow.Decimal(nameof(CommonClassModel.NUMBER_VALUE4)),
                                NUMBER_VALUE5 = datarow.Decimal(nameof(CommonClassModel.NUMBER_VALUE5)),
                                DATETIME_VALUE1 = datarow.DateTime(nameof(CommonClassModel.DATETIME_VALUE1)),
                                DATETIME_VALUE2 = datarow.DateTime(nameof(CommonClassModel.DATETIME_VALUE2)),
                                DATETIME_VALUE3 = datarow.DateTime(nameof(CommonClassModel.DATETIME_VALUE3)),
                                DATETIME_VALUE4 = datarow.DateTime(nameof(CommonClassModel.DATETIME_VALUE4)),
                                DATETIME_VALUE5 = datarow.DateTime(nameof(CommonClassModel.DATETIME_VALUE5)),
                                SORT = datarow.Int(nameof(CommonClassModel.SORT)),

                                KEY_VALUE_DESC = datarow.String(nameof(CommonClassModel.KEY_VALUE_DESC)),
                                TEXT_VALUE1_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE1_DESC)),
                                TEXT_VALUE2_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE2_DESC)),
                                TEXT_VALUE3_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE3_DESC)),
                                TEXT_VALUE4_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE4_DESC)),
                                TEXT_VALUE5_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE5_DESC)),
                                TEXT_VALUE6_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE6_DESC)),
                                TEXT_VALUE7_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE7_DESC)),
                                TEXT_VALUE8_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE8_DESC)),
                                TEXT_VALUE9_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE9_DESC)),
                                TEXT_VALUE10_DESC = datarow.String(nameof(CommonClassModel.TEXT_VALUE10_DESC)),
                                INT_VALUE1_DESC = datarow.String(nameof(CommonClassModel.INT_VALUE1_DESC)),
                                INT_VALUE2_DESC = datarow.String(nameof(CommonClassModel.INT_VALUE2_DESC)),
                                INT_VALUE3_DESC = datarow.String(nameof(CommonClassModel.INT_VALUE3_DESC)),
                                INT_VALUE4_DESC = datarow.String(nameof(CommonClassModel.INT_VALUE4_DESC)),
                                INT_VALUE5_DESC = datarow.String(nameof(CommonClassModel.INT_VALUE5_DESC)),
                                NUMBER_VALUE1_DESC = datarow.String(nameof(CommonClassModel.NUMBER_VALUE1_DESC)),
                                NUMBER_VALUE2_DESC = datarow.String(nameof(CommonClassModel.NUMBER_VALUE2_DESC)),
                                NUMBER_VALUE3_DESC = datarow.String(nameof(CommonClassModel.NUMBER_VALUE3_DESC)),
                                NUMBER_VALUE4_DESC = datarow.String(nameof(CommonClassModel.NUMBER_VALUE4_DESC)),
                                NUMBER_VALUE5_DESC = datarow.String(nameof(CommonClassModel.NUMBER_VALUE5_DESC)),
                                DATETIME_VALUE1_DESC = datarow.String(nameof(CommonClassModel.DATETIME_VALUE1_DESC)),
                                DATETIME_VALUE2_DESC = datarow.String(nameof(CommonClassModel.DATETIME_VALUE2_DESC)),
                                DATETIME_VALUE3_DESC = datarow.String(nameof(CommonClassModel.DATETIME_VALUE3_DESC)),
                                DATETIME_VALUE4_DESC = datarow.String(nameof(CommonClassModel.DATETIME_VALUE4_DESC)),
                                DATETIME_VALUE5_DESC = datarow.String(nameof(CommonClassModel.DATETIME_VALUE5_DESC)),
                            });
                        }

                        //this.DataGridControl?.SortInit(this.ColumnDefinitions, nameof(SelectResultModel.NAMESPACE), SortDirection.Ascending);
                        this.DataGridControl?.SortData();
                        //this.DataGridControl.Pages = new int[] { 1, 2, 3, 4 };
                    }
                }
                else
                {
                    if (response.Message != null)
                    {
                        this.ModalShow("Warning", response.Message, new() { { "Ok", Btn.Warning } }, null);
                    }
                }
            }
            catch (Exception e)
            {
                this.ModalShow("An Exception has occurred.", e.Message, new() { { "Ok", Btn.Danger } }, null);
            }
            finally
            {
                this.A004ViewModel.IsBusy = false;
                this.SetSession(nameof(A004ViewModel), this.A004ViewModel);
            }
        }

        private void SearchCommonClass(int? CLASS_ID)
        {
            if (this.SelectItem == null)
                return;

            if (CLASS_ID == null || CLASS_ID <= 0)
            {
                this.SelectItem = new();
                return;
            }

            Response response;

            try
            {
                if (this.A004ViewModel.IsBusy) return;

                this.A004ViewModel.IsBusy = true;

                ServiceData serviceData = new()
                {
                    Token = this.UserClaim("Token")
                };
                serviceData["1"].CommandText = this.GetAttribute("SearchCommonClass");
                serviceData["1"].AddParameter(nameof(CLASS_ID), DbType.Int, 3, CLASS_ID);
                serviceData["1"].AddParameter("USER_ID", DbType.Int, 3, this.UserClaim("Account.USER_ID").ToInt());

                response = serviceData.ServiceRequest(serviceData);

                if (response.Status == Status.OK)
                {
                    if (response.DataSet != null && response.DataSet.DataTables.Count > 0)
                    {
                        foreach (var datarow in response.DataSet.DataTables[0].DataRows)
                        {
                            this.SelectItem.CLASS_ID = CLASS_ID;
                            this.SelectItem.CLASS_NAME = datarow.String(nameof(this.SelectItem.CLASS_NAME));
                            this.SelectItem.KEY_VALUE_DESC = datarow.String(nameof(this.SelectItem.KEY_VALUE_DESC));
                            this.SelectItem.TEXT_VALUE1_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE1_DESC));
                            this.SelectItem.TEXT_VALUE2_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE2_DESC));
                            this.SelectItem.TEXT_VALUE3_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE3_DESC));
                            this.SelectItem.TEXT_VALUE4_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE4_DESC));
                            this.SelectItem.TEXT_VALUE5_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE5_DESC));
                            this.SelectItem.TEXT_VALUE6_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE6_DESC));
                            this.SelectItem.TEXT_VALUE7_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE7_DESC));
                            this.SelectItem.TEXT_VALUE8_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE8_DESC));
                            this.SelectItem.TEXT_VALUE9_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE9_DESC));
                            this.SelectItem.TEXT_VALUE10_DESC = datarow.String(nameof(this.SelectItem.TEXT_VALUE10_DESC));
                            this.SelectItem.INT_VALUE1_DESC = datarow.String(nameof(this.SelectItem.INT_VALUE1_DESC));
                            this.SelectItem.INT_VALUE2_DESC = datarow.String(nameof(this.SelectItem.INT_VALUE2_DESC));
                            this.SelectItem.INT_VALUE3_DESC = datarow.String(nameof(this.SelectItem.INT_VALUE3_DESC));
                            this.SelectItem.INT_VALUE4_DESC = datarow.String(nameof(this.SelectItem.INT_VALUE4_DESC));
                            this.SelectItem.INT_VALUE5_DESC = datarow.String(nameof(this.SelectItem.INT_VALUE5_DESC));
                            this.SelectItem.NUMBER_VALUE1_DESC = datarow.String(nameof(this.SelectItem.NUMBER_VALUE1_DESC));
                            this.SelectItem.NUMBER_VALUE2_DESC = datarow.String(nameof(this.SelectItem.NUMBER_VALUE2_DESC));
                            this.SelectItem.NUMBER_VALUE3_DESC = datarow.String(nameof(this.SelectItem.NUMBER_VALUE3_DESC));
                            this.SelectItem.NUMBER_VALUE4_DESC = datarow.String(nameof(this.SelectItem.NUMBER_VALUE4_DESC));
                            this.SelectItem.NUMBER_VALUE5_DESC = datarow.String(nameof(this.SelectItem.NUMBER_VALUE5_DESC));
                            this.SelectItem.DATETIME_VALUE1_DESC = datarow.String(nameof(this.SelectItem.DATETIME_VALUE1_DESC));
                            this.SelectItem.DATETIME_VALUE2_DESC = datarow.String(nameof(this.SelectItem.DATETIME_VALUE2_DESC));
                            this.SelectItem.DATETIME_VALUE3_DESC = datarow.String(nameof(this.SelectItem.DATETIME_VALUE3_DESC));
                            this.SelectItem.DATETIME_VALUE4_DESC = datarow.String(nameof(this.SelectItem.DATETIME_VALUE4_DESC));
                            this.SelectItem.DATETIME_VALUE5_DESC = datarow.String(nameof(this.SelectItem.DATETIME_VALUE5_DESC));
                            this.SelectItem.INACTIVE_DATE = datarow.DateTime(nameof(this.SelectItem.INACTIVE_DATE));
                        }
                    }
                }
                else
                {
                    if (response.Message != null)
                    {
                        this.ModalShow("Warning", response.Message, new() { { "Ok", Btn.Warning } }, null);
                    }
                }
            }
            catch (Exception e)
            {
                this.ModalShow("An Exception has occurred.", e.Message, new() { { "Ok", Btn.Danger } }, null);
            }
            finally
            {
                this.A004ViewModel.IsBusy = false;
                this.SetSession(nameof(A004ViewModel), this.A004ViewModel);
            }
        }

        private void Save()
        {
            Response? response;
            string? value;

            response = null;

            try
            {
                if (this.A004ViewModel.IsBusy)
                    return;

                if (this.SelectItem == null)
                    return;

                this.A004ViewModel.IsBusy = true;

                ServiceData serviceData = new()
                {
                    TransactionScope = true,
                    Token = this.UserClaim("Token")
                };
                serviceData["1"].CommandText = this.GetAttribute("Save");
                serviceData["1"].AddParameter(nameof(this.SelectItem.CLASS_VALUE_ID), DbType.Int, 3, "2", nameof(this.SelectItem.CLASS_VALUE_ID), this.SelectItem.CLASS_VALUE_ID);
                serviceData["1"].AddParameter(nameof(this.SelectItem.CLASS_ID), DbType.Int, 3, this.SelectItem.CLASS_ID);
                serviceData["1"].AddParameter(nameof(this.SelectItem.KEY_VALUE), DbType.NVarChar, 200, this.SelectItem.KEY_VALUE);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE1), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE1);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE2), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE2);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE3), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE3);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE4), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE4);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE5), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE5);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE6), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE6);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE7), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE7);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE8), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE8);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE9), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE9);
                serviceData["1"].AddParameter(nameof(this.SelectItem.TEXT_VALUE10), DbType.NVarChar, 4000, this.SelectItem.TEXT_VALUE10);
                serviceData["1"].AddParameter(nameof(this.SelectItem.INT_VALUE1), DbType.Int, 3, this.SelectItem.INT_VALUE1);
                serviceData["1"].AddParameter(nameof(this.SelectItem.INT_VALUE2), DbType.Int, 3, this.SelectItem.INT_VALUE2);
                serviceData["1"].AddParameter(nameof(this.SelectItem.INT_VALUE3), DbType.Int, 3, this.SelectItem.INT_VALUE3);
                serviceData["1"].AddParameter(nameof(this.SelectItem.INT_VALUE4), DbType.Int, 3, this.SelectItem.INT_VALUE4);
                serviceData["1"].AddParameter(nameof(this.SelectItem.INT_VALUE5), DbType.Int, 3, this.SelectItem.INT_VALUE5);
                serviceData["1"].AddParameter(nameof(this.SelectItem.NUMBER_VALUE1), DbType.Decimal, 24, this.SelectItem.NUMBER_VALUE1);
                serviceData["1"].AddParameter(nameof(this.SelectItem.NUMBER_VALUE2), DbType.Decimal, 24, this.SelectItem.NUMBER_VALUE2);
                serviceData["1"].AddParameter(nameof(this.SelectItem.NUMBER_VALUE3), DbType.Decimal, 24, this.SelectItem.NUMBER_VALUE3);
                serviceData["1"].AddParameter(nameof(this.SelectItem.NUMBER_VALUE4), DbType.Decimal, 24, this.SelectItem.NUMBER_VALUE4);
                serviceData["1"].AddParameter(nameof(this.SelectItem.NUMBER_VALUE5), DbType.Decimal, 24, this.SelectItem.NUMBER_VALUE5);
                serviceData["1"].AddParameter(nameof(this.SelectItem.DATETIME_VALUE1), DbType.DateTime, 0, this.SelectItem.DATETIME_VALUE1);
                serviceData["1"].AddParameter(nameof(this.SelectItem.DATETIME_VALUE2), DbType.DateTime, 0, this.SelectItem.DATETIME_VALUE2);
                serviceData["1"].AddParameter(nameof(this.SelectItem.DATETIME_VALUE3), DbType.DateTime, 0, this.SelectItem.DATETIME_VALUE3);
                serviceData["1"].AddParameter(nameof(this.SelectItem.DATETIME_VALUE4), DbType.DateTime, 0, this.SelectItem.DATETIME_VALUE4);
                serviceData["1"].AddParameter(nameof(this.SelectItem.DATETIME_VALUE5), DbType.DateTime, 0, this.SelectItem.DATETIME_VALUE5);
                serviceData["1"].AddParameter(nameof(this.SelectItem.SORT), DbType.Int, 3, this.SelectItem.SORT);
                serviceData["1"].AddParameter("USER_ID", DbType.Int, 3, this.UserClaim("Account.USER_ID").ToInt());

                response = serviceData.ServiceRequest(serviceData);

                if (response.Status == Status.OK)
                {
                    if (response.DataSet != null && response.DataSet.DataTables.Count > 0 && response.DataSet.DataTables[0].DataRows.Count > 0 && this.SelectItem != null && this.SelectItem.CLASS_VALUE_ID == null)
                    {
                        value = response.DataSet.DataTables[0].DataRows[0].String("Value");

                        if (value != null)
                            this.SelectItem.CLASS_VALUE_ID = value.ToInt();
                    }

                    this.ToastShow("Completed", $"{this.GetAttribute("Title")} registered successfully.", Alert.ToastDuration.Long);
                }
                else
                {
                    if (response.Message != null)
                    {
                        this.ModalShow("Warning", response.Message, new() { { "Ok", Btn.Warning } }, null);
                    }
                }
            }
            catch (Exception e)
            {
                this.ModalShow("An Exception has occurred.", e.Message, new() { { "Ok", Btn.Danger } }, null);
            }
            finally
            {
                this.A004ViewModel.IsBusy = false;

                if (response != null && response.Status == Status.OK)
                {
                    this.Search();
                    this.StateHasChanged();
                }
            }
        }

        private void Delete()
        {
            this.ModalShow($"Question", "Do you want to delete?", new() { { "Delete", Btn.Danger }, { "Cancel", Btn.Primary } }, EventCallback.Factory.Create<string>(this, DeleteAction));
        }
        private void DeleteAction(string action)
        {
            Response? response;

            response = null;

            try
            {
                if (action != "Delete") return;

                if (this.A004ViewModel.IsBusy) return;

                if (this.SelectItem == null) return;

                this.A004ViewModel.IsBusy = true;

                if (this.SelectItem.CLASS_VALUE_ID == null)
                {
                    this.ToastShow("Warning", $"Please select a {this.GetAttribute("Title")} to delete.", Alert.ToastDuration.Long);
                    return;
                }

                ServiceData serviceData = new()
                {
                    TransactionScope = true,
                    Token = this.UserClaim("Token")
                };
                serviceData["1"].CommandText = this.GetAttribute("Delete");
                serviceData["1"].AddParameter(nameof(this.SelectItem.CLASS_VALUE_ID), DbType.Int, 3, this.SelectItem.CLASS_VALUE_ID);
                serviceData["1"].AddParameter("USER_ID", DbType.Int, 3, this.UserClaim("Account.USER_ID").ToInt());

                response = serviceData.ServiceRequest(serviceData);

                if (response.Status == Status.OK)
                {
                    this.New();
                    this.ToastShow("Completed", $"{this.GetAttribute("Title")} deleted successfully.", Alert.ToastDuration.Long);
                }
                else
                {
                    if (response.Message != null)
                    {
                        this.ModalShow("Warning", response.Message, new() { { "Ok", Btn.Warning } }, null);
                    }
                }
            }
            catch (Exception e)
            {
                this.ModalShow("An Exception has occurred.", e.Message, new() { { "Ok", Btn.Danger } }, null);
            }
            finally
            {
                this.A004ViewModel.IsBusy = false;

                if (response != null && response.Status == Status.OK)
                {
                    this.Search();
                    this.StateHasChanged();
                }
            }
        }
        #endregion


        #region Event
        private void SearchKeydown(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                this.OnSearch();
            }
        }

        private void RowModify(CommonClassModel item)
        {
            this.SelectItem = new()
            {
                CLASS_VALUE_ID = item.CLASS_VALUE_ID,
                CLASS_ID = item.CLASS_ID,
                CLASS_NAME = item.CLASS_NAME,
                INACTIVE_DATE = item.INACTIVE_DATE,

                KEY_VALUE = item.KEY_VALUE,
                TEXT_VALUE1 = item.TEXT_VALUE1,
                TEXT_VALUE2 = item.TEXT_VALUE2,
                TEXT_VALUE3 = item.TEXT_VALUE3,
                TEXT_VALUE4 = item.TEXT_VALUE4,
                TEXT_VALUE5 = item.TEXT_VALUE5,
                TEXT_VALUE6 = item.TEXT_VALUE6,
                TEXT_VALUE7 = item.TEXT_VALUE7,
                TEXT_VALUE8 = item.TEXT_VALUE8,
                TEXT_VALUE9 = item.TEXT_VALUE9,
                TEXT_VALUE10 = item.TEXT_VALUE10,
                INT_VALUE1 = item.INT_VALUE1,
                INT_VALUE2 = item.INT_VALUE2,
                INT_VALUE3 = item.INT_VALUE3,
                INT_VALUE4 = item.INT_VALUE4,
                INT_VALUE5 = item.INT_VALUE5,
                NUMBER_VALUE1 = item.NUMBER_VALUE1,
                NUMBER_VALUE2 = item.NUMBER_VALUE2,
                NUMBER_VALUE3 = item.NUMBER_VALUE3,
                NUMBER_VALUE4 = item.NUMBER_VALUE4,
                NUMBER_VALUE5 = item.NUMBER_VALUE5,
                DATETIME_VALUE1 = item.DATETIME_VALUE1,
                DATETIME_VALUE2 = item.DATETIME_VALUE2,
                DATETIME_VALUE3 = item.DATETIME_VALUE3,
                DATETIME_VALUE4 = item.DATETIME_VALUE4,
                DATETIME_VALUE5 = item.DATETIME_VALUE5,
                SORT = item.SORT,

                KEY_VALUE_DESC = item.KEY_VALUE_DESC,
                TEXT_VALUE1_DESC = item.TEXT_VALUE1_DESC,
                TEXT_VALUE2_DESC = item.TEXT_VALUE2_DESC,
                TEXT_VALUE3_DESC = item.TEXT_VALUE3_DESC,
                TEXT_VALUE4_DESC = item.TEXT_VALUE4_DESC,
                TEXT_VALUE5_DESC = item.TEXT_VALUE5_DESC,
                TEXT_VALUE6_DESC = item.TEXT_VALUE6_DESC,
                TEXT_VALUE7_DESC = item.TEXT_VALUE7_DESC,
                TEXT_VALUE8_DESC = item.TEXT_VALUE8_DESC,
                TEXT_VALUE9_DESC = item.TEXT_VALUE9_DESC,
                TEXT_VALUE10_DESC = item.TEXT_VALUE10_DESC,
                INT_VALUE1_DESC = item.INT_VALUE1_DESC,
                INT_VALUE2_DESC = item.INT_VALUE2_DESC,
                INT_VALUE3_DESC = item.INT_VALUE3_DESC,
                INT_VALUE4_DESC = item.INT_VALUE4_DESC,
                INT_VALUE5_DESC = item.INT_VALUE5_DESC,
                NUMBER_VALUE1_DESC = item.NUMBER_VALUE1_DESC,
                NUMBER_VALUE2_DESC = item.NUMBER_VALUE2_DESC,
                NUMBER_VALUE3_DESC = item.NUMBER_VALUE3_DESC,
                NUMBER_VALUE4_DESC = item.NUMBER_VALUE4_DESC,
                NUMBER_VALUE5_DESC = item.NUMBER_VALUE5_DESC,
                DATETIME_VALUE1_DESC = item.DATETIME_VALUE1_DESC,
                DATETIME_VALUE2_DESC = item.DATETIME_VALUE2_DESC,
                DATETIME_VALUE3_DESC = item.DATETIME_VALUE3_DESC,
                DATETIME_VALUE4_DESC = item.DATETIME_VALUE4_DESC,
                DATETIME_VALUE5_DESC = item.DATETIME_VALUE5_DESC,
            };
        }

        private void Copy()
        {
            if (this.SelectItem != null)
            {
                this.SelectItem.CLASS_VALUE_ID = null;
                this.SelectItem.KEY_VALUE = null;
                this.SelectItem.SORT = null;
            }
        }
        #endregion
    }
}