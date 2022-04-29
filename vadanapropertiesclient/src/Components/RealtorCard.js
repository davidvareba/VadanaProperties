import React from "react";
import PropTypes from "prop-types";

export default function RealtorCard({ card }) {
    return (
        <div className="realtor-card">
            <div className="img-position">
                <img src='https://lirp.cdn-website.com/48ee6f0b/dms3rep/multi/opt/Portrait-496w.PNG' className="img" />
            </div>
            <div className="realtor-card-body">
                <div className="item">{card.name}</div>
                <div className="item">{card.bio}</div>
                <div className="item">{card.email}</div>
            </div>

        </div>
    );
}

RealtorCard.propTypes = {
    card: PropTypes.shape(PropTypes.obj).isRequired,
};