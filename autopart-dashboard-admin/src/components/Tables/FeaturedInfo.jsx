import "./featuredInfo.css";
import { Centirimi } from "../StyledComponents";

export default function FeaturedInfo() {
  
  return (
    <Centirimi>
    <div className="featured">
      <div className="featuredItem">
        <span className="featuredTitle">Mesazhet</span>
        <div className="featuredMoneyContainer">
          <span className="featuredMoney">0</span>
          <span className="featuredMoneyRate">
         
          </span>
        </div>

      </div>
      <div className="featuredItem">
        <span className="featuredTitle">Përdoruesit</span>
        <div className="featuredMoneyContainer">
          <span className="featuredMoney">5</span>
          {/* <span className="featuredMoneyRate">
            -1.4 <ArrowDownward className="featuredIcon negative"/>
          </span> */}
        </div>
      </div>
    </div>
    </Centirimi>
  );
}
