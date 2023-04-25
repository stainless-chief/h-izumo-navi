import "./map-component.scss";
import React, { useRef, useEffect, useState } from 'react';
import 'mapbox-gl/dist/mapbox-gl.css';
import Map from 'react-map-gl';


function MapComponent() {
  return (
    <Map
      initialViewState={{
        latitude: 35.383822,
        longitude: 132.767306,
        zoom: 12
      }}
      style={{height: 600}}
      mapStyle="mapbox://styles/mapbox/streets-v9"
      mapboxAccessToken={window._env_.REACT_APP_MAPBOX_API_KEY}
    >
    </Map>
  );
};

export { MapComponent };
