using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsApp.Models
{
    class Question
    {

        public string questionOne { get; set; }

        public string questionTwo { get; set; }

        public string questionThree { get; set; }
        public string questionFour { get; set; }
        public string questionFive { get; set; }
        
        //left button
        public string optionOne { get; set; }
        
        //right button
        public string optionTwo { get; set; }

        public string answer { get; set; }
        
        //list of questions
        //string option 1
        //string option 2
        //press a button, changing the content
        //
    }
}
