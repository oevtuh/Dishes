
function ViewModel() {
    var self = this;

    self.dishes = ko.observableArray();

  
    self.updateDishes = function (data) {
       // self.dishes.clean();
        self.dishes(data);
    };

    self.getUrl = function(index) {
        return "/dishes/" + index;
    }


}

//ko.applyBindings(new ViewModel());