var tickets = [];
for (i = 0; i < 100; i++) {
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
            while (arr.length < 99) {
                var randomnumber = Math.ceil(Math.random() * (99))
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



