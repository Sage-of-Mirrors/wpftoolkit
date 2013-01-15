﻿/************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2010-2012 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus edition at http://xceed.com/wpf_toolkit

   Visit http://xceed.com and follow @datagrid on Twitter

  **********************************************************************/

using System;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors
{
  public class ItemsSourceAttributeEditor : TypeEditor<System.Windows.Controls.ComboBox>
  {
    private readonly ItemsSourceAttribute _attribute;

    public ItemsSourceAttributeEditor( ItemsSourceAttribute attribute )
    {
      _attribute = attribute;
    }

    protected override void SetValueDependencyProperty()
    {
      ValueProperty = System.Windows.Controls.ComboBox.SelectedValueProperty;
    }

    protected override void ResolveValueBinding( PropertyItem propertyItem )
    {
      SetItemsSource();
      base.ResolveValueBinding( propertyItem );
    }

    protected override void SetControlProperties()
    {
      Editor.DisplayMemberPath = "DisplayName";
      Editor.SelectedValuePath = "Value";
    }

    private void SetItemsSource()
    {
      Editor.ItemsSource = CreateItemsSource();
    }

    private System.Collections.IEnumerable CreateItemsSource()
    {
      var instance = Activator.CreateInstance( _attribute.Type );
      return ( instance as IItemsSource ).GetValues();
    }
  }
}
