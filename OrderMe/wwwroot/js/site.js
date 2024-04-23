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


// for two maps int the orders
var mapPickup, mapDropoff;
var markerPickup, markerDropoff;

function initTwoMaps() {
    // Initialize pickup map
    mapPickup = new google.maps.Map(document.getElementById('pickupMap'), {
        center: { lat: 42.698334, lng: 24.910543 },
        zoom: 8
    });

    // Add click event listener to the pickup map to place markers
    mapPickup.addListener('click', function (event) {
        placeMarker(event.latLng, 'pickup');
    });

    // Initialize drop-off map
    mapDropoff = new google.maps.Map(document.getElementById('dropoffMap'), {
        center: { lat: 42.698334, lng: 24.910543 },
        zoom: 8
    });

    // Add click event listener to the drop-off map to place markers
    mapDropoff.addListener('click', function (event) {
        placeMarker(event.latLng, 'dropoff');
    });
}

function placeMarker(location, type) {
    if (type === 'pickup') {
        if (markerPickup) {
            markerPickup.setMap(null); // Remove previous marker
        }
        // Place a new marker on the pickup map
        markerPickup = new google.maps.Marker({
            position: location,
            map: mapPickup,
            draggable: true
        });
        // Update hidden input fields with marker's position
        document.getElementById('latitudePick').value = location.lat();
        document.getElementById('longitudePick').value = location.lng();
    } else if (type === 'dropoff') {
        if (markerDropoff) {
            markerDropoff.setMap(null); // Remove previous marker
        }
        // Place a new marker on the drop-off map
        markerDropoff = new google.maps.Marker({
            position: location,
            map: mapDropoff,
            draggable: true
        });
        // Update hidden input fields with marker's position
        document.getElementById('latitudeDrop').value = location.lat();
        document.getElementById('longitudeDrop').value = location.lng();
    }
}
