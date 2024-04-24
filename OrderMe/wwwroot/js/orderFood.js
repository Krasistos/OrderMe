// Handle click event for "Choose item to add" link
document.getElementById('chooseItemLink').addEventListener('click', function (event) {
    event.preventDefault(); // Prevent default link behavior

    var cartId = document.getElementById('CartId').value;

    // Fetch the ChooseItemToAdd partial view
    var url = `/OrderFood/ChooseItemToAdd?cartId=${cartId}`;

    fetch(url)
        .then(response => response.text())
        .then(html => {
            // Replace the content of cartPartial with the fetched partial view
            document.getElementById('cartPartial').innerHTML = html;
        })
        .catch(error => {
            console.error('Error:', error);
        });
});


// Handle click event for "Add item to cart" links
document.querySelectorAll('.addItemToCart').forEach(item => {
    item.addEventListener('click', function (event) {
        event.preventDefault(); // Prevent default link behavior

        var menuItemId = this.getAttribute('data-menuItemId');
        var cartId = this.getAttribute('data-cartId');

        // Fetch the AddMenuItemToCart action
        var url = `/OrderFood/AddMenuItemToCart?menuItemId=${menuItemId}&cartId=${cartId}`;

        fetch(url)
            .then(response => response.text())
            .then(html => {
                // Replace the content of cartPartial with the fetched partial view
                document.getElementById('cartPartial').innerHTML = html;
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });
});
