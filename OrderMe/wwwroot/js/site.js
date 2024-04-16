var map;
var marker;

function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 42.698334, lng: 24.910543 },
        zoom: 8
    });

    // Add click event listener to the map to place markers
    map.addListener('click', function (event) {
        placeMarker(event.latLng);
    });
}

function placeMarker(location) {
    // Remove previous marker if exists
    if (marker) {
        marker.setMap(null);
    }

    // Place a new marker
    marker = new google.maps.Marker({
        position: location,
        map: map,
        draggable: true // Allow marker to be dragged
    });

    // Update hidden input fields with marker's position
    document.getElementById('latitude').value = location.lat();
    document.getElementById('longitude').value = location.lng();
}