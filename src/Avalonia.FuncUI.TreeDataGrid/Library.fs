namespace Avalonia.FuncUI.DSL

open Avalonia.Controls
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Builder

[<AutoOpen>]
module TreeDataGrid =

    let create (attrs: IAttr<TreeDataGrid> list): IView<TreeDataGrid> =
        ViewBuilder.Create<TreeDataGrid>(attrs)

    type TreeDataGrid with

        static member autoDragDropRows<'t when 't :> TreeDataGrid>(autoDragDropRows: bool) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(TreeDataGrid.AutoDragDropRowsProperty, autoDragDropRows, ValueNone)

        static member canUserResizeColumns<'t when 't :> TreeDataGrid>(canUserResizeColumns: bool) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(TreeDataGrid.CanUserResizeColumnsProperty, canUserResizeColumns, ValueNone)

        static member canUserSortColumns<'t when 't :> TreeDataGrid>(canUserSortColumns: bool) : IAttr<'t> =
            AttrBuilder<'t>.CreateProperty<bool>(TreeDataGrid.CanUserSortColumnsProperty, canUserSortColumns, ValueNone)