﻿using System.ComponentModel.Composition;
using Caliburn.Micro;
using DaxStudio.UI.Events;
using DaxStudio.UI.Model;

namespace DaxStudio.UI.ViewModels
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export]
    public class OutputPaneViewModel:ToolWindowBase
    {
        private readonly BindableCollection<OutputMessage> _messages;
        private readonly IEventAggregator _eventAggregator;
        [ImportingConstructor]
        public OutputPaneViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _messages = new BindableCollection<OutputMessage>();
        }

        public IObservableCollection<OutputMessage> Messages { get { return _messages; }
            
        }

        public void AddInformation(string message)
        {
            _messages.Add(new OutputMessage(MessageType.Information, message));
        }

        public void AddInformation(string message, double durationMs)
        {
            _messages.Add(new OutputMessage(MessageType.Information, message,durationMs));
        }

        public void AddWarning(string message)
        {
            _messages.Add(new OutputMessage(MessageType.Warning, message));
        }

        public void AddError(string message)
        {
            _messages.Add(new OutputMessage( MessageType.Error,message));
        }

        public void AddError(string message,int row, int column)
        {
            _messages.Add(new OutputMessage(MessageType.Error, message,row,column ));
        }

        public override string Title
        {
            get { return "Output"; }
        }


        public void MessageDoubleClick(OutputMessage message)
        {
            if (message.Row >= 0 && message.Column >= 0)
            {
                _eventAggregator.PublishOnUIThread(new NavigateToLocationEvent(message.Row, message.Column));
            }
        }

    }


}
