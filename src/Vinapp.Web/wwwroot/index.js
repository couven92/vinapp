$.ajax({
    url: "/api/auth/token",
    data: JSON.stringify({ username: "Njaal", password: "P@ssw0rd!" }),
    type: "POST",
    header: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    },
    contentType: "application/json",
    error: function (data) {
        console.log(data);
    },
    success: function (data) {
        $.ajax({
            url: "/api/Settings/ticketsToUse",
            type: "GET",
            beforeSend: function (xhr) { xhr.setRequestHeader('authorization', 'bearer ' + data.token); },
            success: function (data) {
                var username = "user";
                var tickets = [];
                for (i = 0; i < data.amount; i++) {
                    tickets[i] = { number: i + 1, name: "", bought: false, paid: false, color: "" };
                }

                var app = new Vue({
                    el: '#app',
                    data: {
                        tickets: tickets
                    },
                    methods: {
                        lottery: function (event) {
                            var arr = [];
                            while (arr.length < data.amount) {
                                var randomnumber = Math.ceil(Math.random() * (data.amount) - 1);
                                if (arr.indexOf(randomnumber) > -1) continue;
                                arr[arr.length] = randomnumber;
                            }

                            function highlightStuff(element, index, elements, vue) {
                                return function () {
                                    vue.tickets[element].color = "highlighted";
                                    if (index == elements.length - 1) {
                                        vue.tickets[element].winner = true;
                                        vue.tickets[element].color = "winner";
                                    }
                                    if (index + 1 < elements.length) {
                                        setTimeout(highlightStuff(elements[index + 1], index + 1, elements, vue), 200);
                                    } else {
                                        elements.forEach(function (element, index, elements) {
                                            vue.tickets[element].highlighted = false;
                                            if (!index == elements.length) {
                                                vue.tickets[element].color = "";
                                            }
                                        });
                                    }
                                }
                            }
                            setTimeout(highlightStuff(arr[0], 0, arr, this), 200);
                        },
                        buy: function (ticketnumber) {
                            this.tickets[ticketnumber - 1].bought = true;
                            this.tickets[ticketnumber - 1].name = username;
                        }
                    }
                });
            }
        });
    }
});



