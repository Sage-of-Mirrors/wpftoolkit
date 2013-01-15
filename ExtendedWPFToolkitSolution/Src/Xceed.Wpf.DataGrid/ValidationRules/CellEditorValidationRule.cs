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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;

namespace Xceed.Wpf.DataGrid.ValidationRules
{
  public abstract class CellEditorValidationRule : CellValidationRule
  {
    protected CellEditorValidationRule()
    {
    }

    public override sealed ValidationResult Validate( object value, CultureInfo culture, CellValidationContext context )
    {
      return this.Validate( value, culture, context, context.Cell.CellEditorBoundControl );
    }

    public abstract ValidationResult Validate(
      object value,
      CultureInfo culture,
      CellValidationContext context,
      FrameworkElement cellEditor );
  }
}
