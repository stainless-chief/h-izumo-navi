import "./predict-filter-component.scss";
import { AnalyticsSource } from "../../../../services";
import { Checkbox, Button, FormControl, FormControlLabel, FormGroup, FormLabel } from "@mui/material";
import { useState } from "react";
import { useTranslation } from "react-i18next";

function PredictFilterComponent(
  props: {reloadHeatZone:(code: string) => void})
  {
    const { t } = useTranslation();
    const reloadHeatZone = props.reloadHeatZone;


  return (
  <div className="heat-filter-container">
    <Button onClick={() => { reloadHeatZone(""); }}
            variant="contained">{t("HeatMap.ClearHeatData")}</Button>
  </div>
  );
};

export { PredictFilterComponent };
