﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Features.Alerts
{
    public class AlertService
    {
        private readonly ITempDataDictionary _tempData;

        public AlertService(IHttpContextAccessor contextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(contextAccessor.HttpContext);
        }

        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyle.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            List<Alert> alerts = _tempData.ContainsKey(Alert.TempDataKey) 
                        ? (List<Alert>)_tempData[Alert.TempDataKey] 
                        : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissible = dismissable
            });

            _tempData[Alert.TempDataKey] = alerts;
        }
    }
}
