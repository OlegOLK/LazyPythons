using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LazyPythons.Abstractions.Models;
using LazyPythons.Abstractions.Services;
using LPCommandExecutor.Mappers;
using LPCommandExecutor.Response;
using LPCommandExecutor.ViewModels;

namespace LPCommandExecutor
{
    public class ParserMenuInCaffeNamed : BaseParser
    {
        private readonly IMenuService _menuService;
        private readonly ICaffeService _caffeService;
        private readonly IDishService _dishService;
        private readonly IBeverageService _beverageService;

        public ParserMenuInCaffeNamed(IMenuService menuService,
            ICaffeService caffeService,
            IDishService dishService,
            IBeverageService beverageService)
        {
            _menuService = menuService;
            _caffeService = caffeService;
            _dishService = dishService;
            _beverageService = beverageService;
        }

        protected override string RegexStringPattern => StringConstants.MenuInCaffeNamed;

        public override async Task<IExecutorResponse> ExecuteCommandAsync(string command)
        {
            GroupCollection commandParams = this.GetParametersList(command);

            var parameter = commandParams[1].Value;
            ICaffe caffe = await _caffeService.GetCaffe(parameter).ConfigureAwait(false);
            if (caffe == null)
            {
                return new ExecutorResponse("can not find caffe");
            }

            IMenu menu = await _menuService.GetMenuByCaffeId(caffe.Id).ConfigureAwait(false);
            if (menu == null)
            {
                return new ExecutorResponse($"can not find menu in caffe {caffe.Name}");
            }

            var dishes = await _dishService.GetAllDishesByMenuId(menu.Id).ConfigureAwait(false);
            var beverages = await _beverageService.GetAllBeveragesByMenuId(menu.Id).ConfigureAwait(false);

            return new ExecutorResponse(new List<MenuViewModel> { menu.ToViewModel(caffe.Name, dishes, beverages) });


            ////FIXME: @igk hack to avoid compilation error
            //await Task.Delay(1);
            ////FIXME: NOT IMPLEMENTED
            //return new ExecutorResponse("can not preceed menu");
        }
    }
}

