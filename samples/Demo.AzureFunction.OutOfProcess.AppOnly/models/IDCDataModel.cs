
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute("idc-container", Namespace = "", IsNullable = false)]
public partial class idccontainer
{

    private idccontainerContainerheader containerheaderField;

    private idccontainerIdcsection[] containerbodyField;

    private string containergroupField;

    private string containeridField;

    private string containertypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("container.header")]
    public idccontainerContainerheader containerheader
    {
        get
        {
            return this.containerheaderField;
        }
        set
        {
            this.containerheaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("container.body")]
    [System.Xml.Serialization.XmlArrayItemAttribute("idc-section", IsNullable = false)]
    public idccontainerIdcsection[] containerbody
    {
        get
        {
            return this.containerbodyField;
        }
        set
        {
            this.containerbodyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("container-group")]
    public string containergroup
    {
        get
        {
            return this.containergroupField;
        }
        set
        {
            this.containergroupField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("container-id")]
    public string containerid
    {
        get
        {
            return this.containeridField;
        }
        set
        {
            this.containeridField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("container-type")]
    public string containertype
    {
        get
        {
            return this.containertypeField;
        }
        set
        {
            this.containertypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerContainerheader
{

    private string[] servicesField;

    private string documenttitleField;

    private string documentsubtypeField;

    private ushort publicationyearField;

    private byte publicationmonthField;

    private byte publicationdayField;

    private System.DateTime publicationdateField;

    private System.DateTime retiredateField;

    private System.DateTime releasedateField;

    private idccontainerContainerheaderContainerattachmentlink[] idccontainerattachmentField;

    private byte pagecountField;

    private byte figurecountField;

    private byte tablecountField;

    private idccontainerContainerheaderAuthor[] authorsField;

    private string localeField;

    private object documentdetailsField;

    private string abstract1Field;

    private string countryoforiginField;

    private string regionofpublicationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("service-name", IsNullable = false)]
    public string[] services
    {
        get
        {
            return this.servicesField;
        }
        set
        {
            this.servicesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("document-title")]
    public string documenttitle
    {
        get
        {
            return this.documenttitleField;
        }
        set
        {
            this.documenttitleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("document-subtype")]
    public string documentsubtype
    {
        get
        {
            return this.documentsubtypeField;
        }
        set
        {
            this.documentsubtypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("publication-year")]
    public ushort publicationyear
    {
        get
        {
            return this.publicationyearField;
        }
        set
        {
            this.publicationyearField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("publication-month")]
    public byte publicationmonth
    {
        get
        {
            return this.publicationmonthField;
        }
        set
        {
            this.publicationmonthField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("publication-day")]
    public byte publicationday
    {
        get
        {
            return this.publicationdayField;
        }
        set
        {
            this.publicationdayField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("publication-date", DataType = "date")]
    public System.DateTime publicationdate
    {
        get
        {
            return this.publicationdateField;
        }
        set
        {
            this.publicationdateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("retire-date", DataType = "date")]
    public System.DateTime retiredate
    {
        get
        {
            return this.retiredateField;
        }
        set
        {
            this.retiredateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("release-date", DataType = "date")]
    public System.DateTime releasedate
    {
        get
        {
            return this.releasedateField;
        }
        set
        {
            this.releasedateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("idc-container-attachment")]
    [System.Xml.Serialization.XmlArrayItemAttribute("container-attachment-link", IsNullable = false)]
    public idccontainerContainerheaderContainerattachmentlink[] idccontainerattachment
    {
        get
        {
            return this.idccontainerattachmentField;
        }
        set
        {
            this.idccontainerattachmentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("page-count")]
    public byte pagecount
    {
        get
        {
            return this.pagecountField;
        }
        set
        {
            this.pagecountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("figure-count")]
    public byte figurecount
    {
        get
        {
            return this.figurecountField;
        }
        set
        {
            this.figurecountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("table-count")]
    public byte tablecount
    {
        get
        {
            return this.tablecountField;
        }
        set
        {
            this.tablecountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("author", IsNullable = false)]
    public idccontainerContainerheaderAuthor[] authors
    {
        get
        {
            return this.authorsField;
        }
        set
        {
            this.authorsField = value;
        }
    }

    /// <remarks/>
    public string locale
    {
        get
        {
            return this.localeField;
        }
        set
        {
            this.localeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("document-details")]
    public object documentdetails
    {
        get
        {
            return this.documentdetailsField;
        }
        set
        {
            this.documentdetailsField = value;
        }
    }

    /// <remarks/>
    public string abstract1
    {
        get
        {
            return this.abstract1Field;
        }
        set
        {
            this.abstract1Field = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("country-of-origin")]
    public string countryoforigin
    {
        get
        {
            return this.countryoforiginField;
        }
        set
        {
            this.countryoforiginField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("region-of-publication")]
    public string regionofpublication
    {
        get
        {
            return this.regionofpublicationField;
        }
        set
        {
            this.regionofpublicationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerContainerheaderContainerattachmentlink
{

    private string formatField;

    private string srcField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string src
    {
        get
        {
            return this.srcField;
        }
        set
        {
            this.srcField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerContainerheaderAuthor
{

    private string authornameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("author-name")]
    public string authorname
    {
        get
        {
            return this.authornameField;
        }
        set
        {
            this.authornameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsection
{

    private idccontainerIdcsectionSectionheader sectionheaderField;

    private idccontainerIdcsectionIdcelement[] sectionbodyField;

    private string sectionidField;

    private string sectiontypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("section.header")]
    public idccontainerIdcsectionSectionheader sectionheader
    {
        get
        {
            return this.sectionheaderField;
        }
        set
        {
            this.sectionheaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute("section.body")]
    [System.Xml.Serialization.XmlArrayItemAttribute("idc-element", IsNullable = false)]
    public idccontainerIdcsectionIdcelement[] sectionbody
    {
        get
        {
            return this.sectionbodyField;
        }
        set
        {
            this.sectionbodyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("section-id")]
    public string sectionid
    {
        get
        {
            return this.sectionidField;
        }
        set
        {
            this.sectionidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("section-type")]
    public string sectiontype
    {
        get
        {
            return this.sectiontypeField;
        }
        set
        {
            this.sectiontypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionSectionheader
{

    private string sectionnameField;

    private string sectiontitleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("section-name")]
    public string sectionname
    {
        get
        {
            return this.sectionnameField;
        }
        set
        {
            this.sectionnameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("section-title")]
    public string sectiontitle
    {
        get
        {
            return this.sectiontitleField;
        }
        set
        {
            this.sectiontitleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelement
{

    private idccontainerIdcsectionIdcelementElementheader elementheaderField;

    private idccontainerIdcsectionIdcelementElementbody elementbodyField;

    private string elementidField;

    private string elementtypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.header")]
    public idccontainerIdcsectionIdcelementElementheader elementheader
    {
        get
        {
            return this.elementheaderField;
        }
        set
        {
            this.elementheaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.body")]
    public idccontainerIdcsectionIdcelementElementbody elementbody
    {
        get
        {
            return this.elementbodyField;
        }
        set
        {
            this.elementbodyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-id")]
    public string elementid
    {
        get
        {
            return this.elementidField;
        }
        set
        {
            this.elementidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-type")]
    public string elementtype
    {
        get
        {
            return this.elementtypeField;
        }
        set
        {
            this.elementtypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementheader
{

    private string elementtitleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-title")]
    public string elementtitle
    {
        get
        {
            return this.elementtitleField;
        }
        set
        {
            this.elementtitleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbody
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelement[] idcelementField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idc-element")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelement[] idcelement
    {
        get
        {
            return this.idcelementField;
        }
        set
        {
            this.idcelementField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelement
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementheader elementheaderField;

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbody elementbodyField;

    private string elementidField;

    private string elementtypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.header")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementheader elementheader
    {
        get
        {
            return this.elementheaderField;
        }
        set
        {
            this.elementheaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.body")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbody elementbody
    {
        get
        {
            return this.elementbodyField;
        }
        set
        {
            this.elementbodyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-id")]
    public string elementid
    {
        get
        {
            return this.elementidField;
        }
        set
        {
            this.elementidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-type")]
    public string elementtype
    {
        get
        {
            return this.elementtypeField;
        }
        set
        {
            this.elementtypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementheader
{

    private string elementcaptionField;

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementheaderIdcelementattachment idcelementattachmentField;

    private string elementtitleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-caption")]
    public string elementcaption
    {
        get
        {
            return this.elementcaptionField;
        }
        set
        {
            this.elementcaptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idc-element-attachment")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementheaderIdcelementattachment idcelementattachment
    {
        get
        {
            return this.idcelementattachmentField;
        }
        set
        {
            this.idcelementattachmentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-title")]
    public string elementtitle
    {
        get
        {
            return this.elementtitleField;
        }
        set
        {
            this.elementtitleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementheaderIdcelementattachment
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink elementattachmentlinkField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-attachment-link")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink elementattachmentlink
    {
        get
        {
            return this.elementattachmentlinkField;
        }
        set
        {
            this.elementattachmentlinkField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink
{

    private string formatField;

    private string srcField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string src
    {
        get
        {
            return this.srcField;
        }
        set
        {
            this.srcField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbody
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelement[] idcelementField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idc-element")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelement[] idcelement
    {
        get
        {
            return this.idcelementField;
        }
        set
        {
            this.idcelementField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelement
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheader elementheaderField;

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbody elementbodyField;

    private string elementidField;

    private string elementtypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.header")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheader elementheader
    {
        get
        {
            return this.elementheaderField;
        }
        set
        {
            this.elementheaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.body")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbody elementbody
    {
        get
        {
            return this.elementbodyField;
        }
        set
        {
            this.elementbodyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-id")]
    public string elementid
    {
        get
        {
            return this.elementidField;
        }
        set
        {
            this.elementidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-type")]
    public string elementtype
    {
        get
        {
            return this.elementtypeField;
        }
        set
        {
            this.elementtypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheader
{

    private string elementcaptionField;

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachment idcelementattachmentField;

    private string elementtitleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-caption")]
    public string elementcaption
    {
        get
        {
            return this.elementcaptionField;
        }
        set
        {
            this.elementcaptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idc-element-attachment")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachment idcelementattachment
    {
        get
        {
            return this.idcelementattachmentField;
        }
        set
        {
            this.idcelementattachmentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-title")]
    public string elementtitle
    {
        get
        {
            return this.elementtitleField;
        }
        set
        {
            this.elementtitleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachment
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink elementattachmentlinkField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-attachment-link")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink elementattachmentlink
    {
        get
        {
            return this.elementattachmentlinkField;
        }
        set
        {
            this.elementattachmentlinkField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink
{

    private string formatField;

    private string srcField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string src
    {
        get
        {
            return this.srcField;
        }
        set
        {
            this.srcField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbody
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelement[] idcelementField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idc-element")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelement[] idcelement
    {
        get
        {
            return this.idcelementField;
        }
        set
        {
            this.idcelementField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelement
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheader elementheaderField;

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbody elementbodyField;

    private string elementidField;

    private string elementtypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.header")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheader elementheader
    {
        get
        {
            return this.elementheaderField;
        }
        set
        {
            this.elementheaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.body")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbody elementbody
    {
        get
        {
            return this.elementbodyField;
        }
        set
        {
            this.elementbodyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-id")]
    public string elementid
    {
        get
        {
            return this.elementidField;
        }
        set
        {
            this.elementidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-type")]
    public string elementtype
    {
        get
        {
            return this.elementtypeField;
        }
        set
        {
            this.elementtypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheader
{

    private string elementcaptionField;

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachment idcelementattachmentField;

    private string elementtitleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-caption")]
    public string elementcaption
    {
        get
        {
            return this.elementcaptionField;
        }
        set
        {
            this.elementcaptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idc-element-attachment")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachment idcelementattachment
    {
        get
        {
            return this.idcelementattachmentField;
        }
        set
        {
            this.idcelementattachmentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-title")]
    public string elementtitle
    {
        get
        {
            return this.elementtitleField;
        }
        set
        {
            this.elementtitleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachment
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink elementattachmentlinkField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-attachment-link")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink elementattachmentlink
    {
        get
        {
            return this.elementattachmentlinkField;
        }
        set
        {
            this.elementattachmentlinkField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheaderIdcelementattachmentElementattachmentlink
{

    private string formatField;

    private string srcField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string src
    {
        get
        {
            return this.srcField;
        }
        set
        {
            this.srcField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbody
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelement[] idcelementField;

    private string[] textField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("idc-element")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelement[] idcelement
    {
        get
        {
            return this.idcelementField;
        }
        set
        {
            this.idcelementField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string[] Text
    {
        get
        {
            return this.textField;
        }
        set
        {
            this.textField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelement
{

    private idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheader elementheaderField;

    private string elementbodyField;

    private string elementidField;

    private string elementtypeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.header")]
    public idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheader elementheader
    {
        get
        {
            return this.elementheaderField;
        }
        set
        {
            this.elementheaderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element.body")]
    public string elementbody
    {
        get
        {
            return this.elementbodyField;
        }
        set
        {
            this.elementbodyField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-id")]
    public string elementid
    {
        get
        {
            return this.elementidField;
        }
        set
        {
            this.elementidField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("element-type")]
    public string elementtype
    {
        get
        {
            return this.elementtypeField;
        }
        set
        {
            this.elementtypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class idccontainerIdcsectionIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementbodyIdcelementElementheader
{

    private string elementtitleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("element-title")]
    public string elementtitle
    {
        get
        {
            return this.elementtitleField;
        }
        set
        {
            this.elementtitleField = value;
        }
    }
}

