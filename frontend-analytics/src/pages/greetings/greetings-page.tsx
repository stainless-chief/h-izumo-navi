import "../../locales/i18n";
import "./greetings-page.scss";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";

function GreetingsPage() {
  const { t } = useTranslation();

  return (
  <div className="navigation">
    <Link to="/heatmap">
      <img src={("/assets/images/heatmap.png")} alt={t("Navigation.HeatmapAlt")}/>
      <b>{t("Navigation.Heatmap")}</b>
    </Link>
    <Link to="/satisfaction">
      <img src={("/assets/images/satisfaction.png")} alt={t("Navigation.SatisfactionAlt")}/>
      <b>{t("Navigation.Satisfaction")}</b>
    </Link>
    <Link to="/statistics">
      <img src={("/assets/images/statistics.png")} alt={t("Navigation.StatisticsAlt")}/>
      <b>{t("Navigation.Statistics")}</b>
    </Link>
    <Link to="/predict">
      <img src={("/assets/images/machine.png")} alt={t("Navigation.MachineLearningAlt")}/>
      <b>{t("Navigation.MachineLearning")}</b>
    </Link>

  </div>
  );
}

export { GreetingsPage };
