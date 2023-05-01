import "./header.scss";
import { Link } from "react-router-dom";
import { useTranslation } from "react-i18next";
import "../../locales/i18n";

function Header() {
  const { t } = useTranslation();

  return (
  <header>
    <Link className="full-size" to="/"><b>{t("Header.Full")}</b></Link>
  </header>
  );
}

export { Header };
