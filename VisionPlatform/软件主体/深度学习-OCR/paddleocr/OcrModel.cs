namespace VisionPlatform.多线插.检测功能.深度学习.paddleocr
{
    public  class OcrModel
    {
        public string det_model_path;

        public string cls_model_path;

        public string rec_model_path;

        public string dict_path;

        public OcrModel()
        {
        }

        public OcrModel(string det_model_path, string cls_model_path, string rec_model_path, string dict_path)
        {
            this.det_model_path = det_model_path;
            this.cls_model_path = cls_model_path;
            this.rec_model_path = rec_model_path;
            this.dict_path = dict_path;
        }

        //public static async Task<OcrModel> GetOnlineOcrModel(Language language = Language.ch_PP_OCRv4, bool det = true, bool cls = true, bool rec = true)
        //{
        //    OcrModel model = new OcrModel();
        //    switch (language)
        //    {
        //        case Language.ch_PP_OCRv4:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_PP_OCRv4_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_PP_OCRv4_server:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_server_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_PP_OCRv4_server_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_PP_OCRv3_slim:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv3_det_slim);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_PP_OCRv3_rec_slim);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv3_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_PP_OCRv2_slim:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv2_det_slim);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_PP_OCRv2_rec_slim);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_PP_OCRv2:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv2_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_PP_OCRv2_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_ppocr_mobile_slim_v2:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_ppocr_mobile_slim_v2_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_ppocr_mobile_slim_v2_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_ppocr_mobile_v2:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_ppocr_mobile_v2_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_ppocr_mobile_v2_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.ch_ppocr_server_v2:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ch_ppocr_server_v2_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocr_keys_v1);
        //                break;
        //            }
        //        case Language.en_PP_OCRv4:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.en_PP_OCRv4_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.en_dict);
        //                break;
        //            }
        //        case Language.en_PP_OCRv3_slim:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.en_PP_OCRv3_rec_slim);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.en_dict);
        //                break;
        //            }
        //        case Language.en_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.en_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.en_dict);
        //                break;
        //            }
        //        case Language.en_number_mobile_slim_v2:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.en_number_mobile_slim_v2_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.en_dict);
        //                break;
        //            }
        //        case Language.en_number_mobile_v2:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.en_number_mobile_v2_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.en_dict);
        //                break;
        //            }
        //        case Language.korean_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.korean_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.korean_dict);
        //                break;
        //            }
        //        case Language.japan_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.japan_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.japan_dict);
        //                break;
        //            }
        //        case Language.chinese_cht_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.chinese_cht_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.chinese_cht_dict);
        //                break;
        //            }
        //        case Language.te_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.te_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.te_dict);
        //                break;
        //            }
        //        case Language.ka_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ka_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ka_dict);
        //                break;
        //            }
        //        case Language.ta_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.ta_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ta_dict);
        //                break;
        //            }
        //        case Language.latin_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.latin_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.latin_dict);
        //                break;
        //            }
        //        case Language.arabic_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.arabic_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.arabic_dict);
        //                break;
        //            }
        //        case Language.cyrillic_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.cyrillic_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.cyrillic_dict);
        //                break;
        //            }
        //        case Language.devanagari_PP_OCRv3:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.ch_PP_OCRv4_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.ch_ppocr_mobile_v2_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.devanagari_PP_OCRv3_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.devanagari_dict);
        //                break;
        //            }
        //        case Language.PP_OCRv5_server:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.PP_OCRv5_server_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.PP_OCRv5_server_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.PP_OCRv5_server_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocrv5_dict);
        //                break;
        //            }
        //        case Language.PP_OCRv5_mobile:
        //            {
        //                OcrModel ocrModel;
        //                if (det)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.det_model_path = await OCRDetModels.Get(OCRDetModels.OCRDetModelsType.PP_OCRv5_mobile_det);
        //                }

        //                if (cls)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.cls_model_path = await OCRClsModels.Get(OCRClsModels.OCRClsModelsType.PP_OCRv5_mobile_cls);
        //                }

        //                if (rec)
        //                {
        //                    ocrModel = model;
        //                    ocrModel.rec_model_path = await OCRRecModels.Get(OCRRecModels.OCRRecModelsType.PP_OCRv5_mobile_rec);
        //                }

        //                ocrModel = model;
        //                ocrModel.dict_path = await OCRDicts.Get(OCRDicts.OCRDictsType.ppocrv5_dict);
        //                break;
        //            }
        //        default:
        //            throw new Exception("Model selection error!");
        //    }

        //    return model;
        //}
    }
}

