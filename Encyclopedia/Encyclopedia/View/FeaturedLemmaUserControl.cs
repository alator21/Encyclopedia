﻿using System.Windows.Forms;
using UI;
using Encyclopedia.Controller;
using Encyclopedia.Model;
using System.Text;

namespace Encyclopedia.View
{
    /// <summary>
    /// A User Control that displays a Random Lemma from the database
    /// </summary>
    public partial class FeaturedLemmaUserControl : UserControl
    {
        /// <summary>
        /// A static reference to the Instance of this User Control
        /// </summary>
        private static FeaturedLemmaUserControl _instance;

        /// <summary>
        /// A static reference to the public Instance of the Control
        /// </summary>
        public static FeaturedLemmaUserControl Instance
        {
            get
            {
                
                if (_instance == null)
                    _instance = new FeaturedLemmaUserControl();
                return _instance;

            }
        }


        #region Constructors
        public FeaturedLemmaUserControl()
        {
            //init the database connection -- not the best place here
            
            InitializeComponent();

            SetRandomLemma();
        }
        #endregion

        #region Public methods
        // Use this to Search
        public void SetRandomLemma()
		{
			// get a random lemma to display
			Lemma lemma = Random.getRandomLemma();
			
			// configure the web browser document text accordingly
			string titleStyle = " style=\"display: block; " +
				"font-size: 3em;" +
				"margin-top: 0.67em; " +
				"margin-bottom: 0.67em; " +
				"margin-left: 0; " +
				"margin-right: 0; " +
				"font-weight: bold;\"";
			lemmaOfTheDayWebBrowser.DocumentText = "<h1" + titleStyle + ">" + lemma.Title.Replace("_", " ") + "</h1>" + Encoding.UTF8.GetString(lemma.Body);
			if (!StartPage.recentLemmata.Contains(lemma.Title))
				StartPage.recentLemmata.Add(lemma.Title);
		}
        #endregion

    }
}
