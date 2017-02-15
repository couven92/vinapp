var app = new Vue({
    el: '#app',
    data: {
        tickets: null
    },
    created: function () {

    }

})

$(document).ready(function () {
    var tickets = [];
    for (i = 0; i < 100; i++) {
    tickets[i] = {number: i+1, name: "njaal", paid: true }
}
app.tickets = tickets;

});