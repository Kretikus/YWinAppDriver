// Copyright (c) https://github.com/licanhua/YWinAppDriver. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WinAppDriver
{
  public class Capabilities
  {
    [JsonProperty(Required = Required.DisallowNull)]
    public string app;
    public string attachToTopLevelWindowClassName;
    public string appArguments;
    public string appWorkingDir;
    public string forceMatchAppTitle;
    public string forceMatchClassName;
    public string clickWithInvoke; // Invoke has better performance over click.
  }

  public class W3CCapabilities
  {
    [JsonProperty("appium:app", Required = Required.DisallowNull)]
    public string app;
    [JsonProperty("appium:attachToTopLevelWindowClassName")]
    public string attachToTopLevelWindowClassName;
    [JsonProperty("appium:appArguments")]
    public string appArguments;
    [JsonProperty("appium:appWorkingDir")]
    public string appWorkingDir;
    [JsonProperty("appium:forceMatchAppTitle")]
    public string forceMatchAppTitle;
    [JsonProperty("appium:forceMatchClassName")]
    public string forceMatchClassName;
    [JsonProperty("appium:clickWithInvoke")]
    public string clickWithInvoke; // Invoke has better performance over click.

    public Capabilities GetBaseCapabilities()
    {
      var ret = new Capabilities();
      ret.app = app;
      ret.appArguments = appArguments;
      ret.appWorkingDir = appWorkingDir;
      ret.forceMatchAppTitle = forceMatchAppTitle;
      ret.forceMatchClassName = forceMatchClassName;
      ret.clickWithInvoke = clickWithInvoke;
      return ret;
    }
  }
}
