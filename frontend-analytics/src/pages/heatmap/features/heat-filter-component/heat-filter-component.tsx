import "./heat-filter-component.scss";
import { AnalyticsSource } from "../../../../services";
import { Checkbox, Button, FormControl, FormControlLabel, FormGroup, FormLabel } from "@mui/material";
import { useState } from "react";
import { useTranslation } from "react-i18next";

function HeatFilterComponent(
  props: {analyticsSources: AnalyticsSource[], reloadHeatZone:(sourceCodes: string[]) => void}) {
  const { t } = useTranslation();
  const analyticsSources = props.analyticsSources;
  const reloadHeatZone = props.reloadHeatZone;
  const [checkedList, setCheckedList] = useState<string[]>([]);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.checked) {
      setCheckedList([
        ...checkedList,
        event.target.value,
      ]);
    } else {
      setCheckedList(
        checkedList.filter(x => x !== event.target.value),
      );
    }
  };

  return (
<div className="heat-filter-container">
  <FormControl component="fieldset" variant="standard">
    <FormLabel component="legend">{t("HeatMap.FilterHeader")}</FormLabel>
    {analyticsSources.map(x => { 
      return (<FormGroup>
        <FormControlLabel 
                  control={ <Checkbox value={x.code} onChange={handleChange} /> }
                  label={x.name + " [" +x.totalEvents +"]"}/>
        </FormGroup>) })
    }
  </FormControl>
  <Button disabled={checkedList?.length < 1} 
          onClick={() => { reloadHeatZone(checkedList); }}
          variant="contained">{t("HeatMap.LoadHeatData")}</Button>
  <Button onClick={() => { reloadHeatZone([]); }}
          variant="contained">{t("HeatMap.ClearHeatData")}</Button>
  </div>
  );
};

export { HeatFilterComponent };
