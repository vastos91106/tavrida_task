import React from "react";
import BarLoader from "react-spinners/BarLoader";
import {css} from "aphrodite";

import style from "./style";

function Loader() {
    return (
        <div  className={css(style.container)}>
            <BarLoader/>
        </div>
    )
}

export default React.memo(Loader);
