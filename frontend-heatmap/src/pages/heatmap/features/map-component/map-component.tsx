import "./map-component.scss";

function MapComponent() {
  return (
  <div className="actual-map-container">
    map d
    {process.env.REACT_APP_BING_MAPS_API_KEY}
  </div>
  );
};

export { MapComponent };
