var app = new Vue({
    el: '#app',
    data: {
        tickets: null
    },
    methods: {
        lottery: function (event) {
          
        }
    }
})

var tickets = [];
for (i = 0; i < 100; i++) {
    tickets[i] = { number: i + 1, name: "njaal", paid: true }
}
app.tickets = tickets;
