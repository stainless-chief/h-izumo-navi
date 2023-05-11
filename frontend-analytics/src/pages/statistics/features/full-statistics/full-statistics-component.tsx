import "./full-statistics-component.scss";
import { StatisticItem } from "../../../../services";
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { useTranslation } from "react-i18next";
import { Button } from "@mui/material";

function StatisticsComponent(
  props: {
    statistics: StatisticItem[], 
    moveToLocation:(latitude:number, longitude: number) => void})
  {
    const { t } = useTranslation();
    const statistics = props.statistics;
    const moveToLocation = props.moveToLocation;

    const renderFlyToButton = (params) => { 
      return (
      <Button
        variant="contained"
        color="primary"
        size="small"
        style={{ marginLeft: 16 }}
        onClick=
        {() => {
          moveToLocation(params.row.coordinates[0].x, params.row.coordinates[0].y);
        }}>
          {t("Statistics.MoveToLocation")}
      </Button>
    )}

    let columns: GridColDef[] = [{
      field: 'actions',
      headerName: '',
      width: 100,
      renderCell: renderFlyToButton,},
      { field: 'placeName', headerName: 'Place Name', width: 250 },
      { field: 'temperature', headerName: 'Temperature', width: 140 },
    ];

    const sources = 
        props.statistics.flatMap(x => x.sources)
                        .filter(function({code}) {
                          return !this.has(code) && this.add(code);
                        }, new Set());

    sources.forEach(function (value) {
      columns.push(
        { 
          field: 'sources_'+ value.code, 
          width: 150,
          headerName: value.name,
          valueGetter: (params) => {
            return params.row.sources.find(x=>x.code === value.code).totalEvents;
          },
        }
      )
    }); 
    
    return (
    <div className="full-statistics-container">
      <DataGrid
          rows={statistics}
          columns={columns}
          getRowId={(row: any) =>  row.placeName}
          hideFooterPagination
          hideFooterSelectedRowCount/>
    </div>
  );
};

export { StatisticsComponent };
