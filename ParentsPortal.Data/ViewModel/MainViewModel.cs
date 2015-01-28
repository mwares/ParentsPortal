using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ParentsPortal.Data.Model;
using System;
using System.Collections.ObjectModel;

namespace ParentsPortal.Data.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IParentsPortalService _parentsPortalService;
        private readonly INavigationService _navigationService;
        private bool _isLoading;

        private RelayCommand _getChildrenCommand;
        private RelayCommand<ParentsPortalViewModel> _showChildDetailsCommand;

        public ObservableCollection<ParentsPortalViewModel> ParentsPortalViewModel
        {
            get;
            private set;
        }

        public string LastLoadedFormatted
        {
            get
            {
                return _isLoading
                    ? "Loading..."
                    : "Done Loading";
            }
        }

        public RelayCommand GetChildrenCommand
        {
            get
            {
                return _getChildrenCommand
                    ?? (_getChildrenCommand = new RelayCommand(
                        async () =>
                        {
                            ParentsPortalViewModel.Clear();
                            _isLoading = true;
                            RaisePropertyChanged(() => LastLoadedFormatted);

                            try
                            {
                                Person parent = new Person();
                                parent.PersonId = "";
                                var list = await _parentsPortalService.GetChildren(parent);

                                foreach (var person in list)
                                {
                                    ParentsPortalViewModel.Add(new ParentsPortalViewModel(_parentsPortalService, person));
                                }
                                _isLoading = false;
                            }
                            catch (Exception ex)
                            {
                                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                                dialog.ShowError(ex, "Error when get children", "Ok", null);
                            }
                            _isLoading = false;
                            RaisePropertyChanged(() => LastLoadedFormatted);
                        }));
            }
        }

        public RelayCommand<ParentsPortalViewModel> ShowChildDetailsCommand
        {
            get
            {
                return _showChildDetailsCommand
                    ??(_showChildDetailsCommand = new RelayCommand<ParentsPortalViewModel>(
                        parentsPortal =>
                        {
                            if(!ShowChildDetailsCommand.CanExecute(parentsPortal))
                            {
                                return;
                            }
                                _navigationService.NavigateTo(ViewModelLocator.DetailsPageKey, parentsPortal);
                        },
                            parentsPortal => parentsPortal !=null));
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IParentsPortalService parentsPortalService, INavigationService navigationService)
        {
            _parentsPortalService = parentsPortalService;
            _navigationService = navigationService;
            ParentsPortalViewModel = new ObservableCollection<ParentsPortalViewModel>();
        }
    }
}