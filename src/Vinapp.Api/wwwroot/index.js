$.ajax({
    url: "/api/auth/token",
    data: JSON.stringify({ username: "Njaal", password: "P@ssw0rd!" }),
    type: "POST",
    header: {
        'Content-Type': 'application/json',
        'Accept' : 'application/json'
    },
    contentType: "application/json",
    error: function(data) {
        console.log(data);
    },
    success: function (data) {
        $.ajax({
            url: "/api/Settings/ticketsToUse",
            type: "GET",
            beforeSend: function (xhr) { xhr.setRequestHeader('authorization', 'bearer ' + data.token); },
            success: function (data) {
               
                var winners = [];

                var user = {
                    name: "Bente",
                    isBente: true
                };
                var tickets = [];
                const names = ["Magnus", "Njaal"];
                const boughtValues = [true, false, true];
                for (i = 0; i < data.amount; i++) {
                    tickets[i] = { number: i + 1, name: names[i % 2], bought: boughtValues[i % 3], paid: false, color: "" };
                }
                const lotterymode = user.isBente;

                var app = new Vue({
                    el: '#app',
                    data: {
                        tickets: tickets,
                        winners: winners,
                        lotterymode: lotterymode
                    },
                    methods: {
                        lottery: function (event) {
                            var excludedNumbers = [];

                            resetBoard(this.tickets);
                            pickWinner();

                            function pickWinner() {
                                while (excludedNumbers.length < tickets.length - winners.length) {
                                    var randomnumber = Math.ceil(Math.random() * (tickets.length) -1);
                                    if (alreadyPicked(randomnumber)) continue;
                                    excludedNumbers[excludedNumbers.length] = randomnumber;
                                }
                            }

                            function alreadyPicked(pickedNumber) {
                                return excludedNumbers.indexOf(pickedNumber) > -1
                                    || winners.indexOf(pickedNumber +1) > -1;
                            }

                            function highlightStuff(element, index, elements, vue) {
                                return function () {
                                    vue.tickets[element].color = "highlighted";
                                    if (index == elements.length - 1) {
                                        setWinner(vue.tickets[element])
                                    }
                                    if (index + 1 < elements.length) {
                                        setTimeout(highlightStuff(elements[index + 1], index + 1, elements, vue), 1);
                                    }
                                }
                            }

                            function setWinner(ticket) {
                                if (ticket.bought) {
                                    winners.push(ticket.number);
                                    ticket.color = "winner";
                                } else {
                                    ticket.color = "nowinner";
                                }
                                ticket.winner = true;
                            }

                            function resetBoard(tickets) {
                                tickets.forEach(function(ticket) {
                                    if (ticket.winner) {
                                        ticket.color = "alreadyWon";
                                    } else {
                                        ticket.color = "";
                                    }
                                })
                            }

                            setTimeout(highlightStuff(excludedNumbers[0], 0, excludedNumbers, this), 1);
                        },

                        buy: function (ticketnumber) {
                            this.tickets[ticketnumber - 1].bought = true;
                            this.tickets[ticketnumber - 1].name = user.name;
                        }
                    }
                });
            }
        });
    }
});



