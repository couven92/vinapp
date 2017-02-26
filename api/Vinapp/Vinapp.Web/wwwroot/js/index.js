
$.getJSON('http://localhost:9888/api/Settings/ticketsToUse', function(data) {
var tickets = [];
for (i = 0; i < data.amount; i++) {
    tickets[i] = { number: i+1, name: "njaal", paid: true, color: "" }
}

var app = new Vue({
    el: '#app',
    data: {
        tickets: tickets
    },
    methods: {
        lottery: function (event) {
            var arr = []
            while (arr.length < data.amount) {
                var randomnumber = Math.ceil(Math.random() * (data.amount)-1)
                if (arr.indexOf(randomnumber) > -1) continue;
                arr[arr.length] = randomnumber;
            }

            function highlightStuff(element, index, elements) {
                return function () {
                    console.log(element + " - "+index);
                    this.tickets[element].color = "highlighted";
                    if (index == elements.length - 1) {
                        this.tickets[element].winner = true;
                        this.tickets[element].color = "winner";
                    }
                    if (index + 1 < elements.length) {
                        setTimeout(highlightStuff(elements[index + 1], index + 1, elements), 200);
                    } else {
                        elements.forEach(function (element, index, elements) {
                            this.tickets[element].highlighted = false;
                            if (!index == elements.length) {
                                this.tickets[element].color = "";
                            }
                        })
                    }
                }
            }

            setTimeout(highlightStuff(arr[0], 0, arr), 200);


        }
    }
});

});



