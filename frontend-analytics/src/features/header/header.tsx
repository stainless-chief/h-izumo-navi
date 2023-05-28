import "./header.scss";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import "../../locales/i18n";
import { useLocation } from 'react-router-dom';

function Header() {
  const { t } = useTranslation();
  const { pathname } = useLocation();
  var text = t("Header.Analytics");

  switch(pathname)
  {
    case "/heatmap": {
      text = t("Header.Heatmap");
      break;
    }
    case "/statistics": {
      text = t("Header.Statistics");
      break;
    }
    case "/predict": {
      text = t("Header.MachineLearning");
      break;
    }
  }

  return (
  <header>
    <Link className="full-size" to="/"><b>{text}</b></Link>
  </header>
  );
}

export { Header };
