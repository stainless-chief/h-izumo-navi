import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import "../../locales/i18n";
import "./greetings-page.scss";

function GreetingsPage() {
  const { t } = useTranslation();

  return (
  <div className="navigation">
    <Link to="/heatmap">
      <img src={("/assets/images/heatmap.png")}/>
      <b>{t("Navigation.Heatmap")}</b>
    </Link>
    <Link to="/statistics">
      <img src={("/assets/images/statistics.png")}/>
      <b>{t("Navigation.Statistics")}</b>
    </Link>
  </div>
  );
}

export { GreetingsPage };
