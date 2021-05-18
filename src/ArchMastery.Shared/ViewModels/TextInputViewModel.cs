﻿using Microsoft.Toolkit.Mvvm.ComponentModel;

#if !UAP
#nullable enable
#endif

namespace ArchMastery.Builder.ViewModels
{
    public class TextInputViewModel : ObservableObject
    {
        private string _question = string.Empty;
        private string _answer = string.Empty;

        public string Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }

        public string Answer
        {
            get => _answer;
            set => SetProperty(ref _answer, value);
        }
    }
}